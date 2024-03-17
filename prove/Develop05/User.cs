using System.Xml.Serialization;
using System.IO;
class User
{
    private int _points;
    private string _name;
    private List<Goal> _goals = new List<Goal>();

    public bool LoadUserFile(string filepath)
    {
        if (File.Exists(filepath))
        {
            _goals.Clear();
            string[] goalStrings = System.IO.File.ReadAllLines(filepath);
            foreach (string g in goalStrings)
            {

                string[] parts = g.Split("||");
                if (parts[0] == "User")
                {
                    _name = parts[1];
                    _points = int.Parse(parts[2]);
                }
                else if (parts[0] == "EternalGoal")
                {
                    //_name + "||" + _description + "||" + _reward + "||" + _isGoalComplete;
                    _goals.Add(new EternalGoal(parts[1], parts[2], parts[3], parts[4]));
                }
                else if (parts[0] == "ChecklistGoal")
                {
                    //_name + "||" + _description + "||" + _reward + "||" + _isGoalComplete + "||" + _totalSteps + "||" + _currentStep + "||" + _stepReward;
                    _goals.Add(new ChecklistGoal(parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7]));
                }
                else if (parts[0] == "Goal")
                {
                    //_name + "||" + _description + "||" + _reward + "||" + _isGoalComplete;
                    _goals.Add(new Goal(parts[1], parts[2], parts[3], parts[4]));

                }
                else
                {
                    //you did something wrong to get here
                }
            }
            return true;
        }
        else
        {
            Console.WriteLine($"Sorry, {filepath} does not exist.");
            return false;
        }
    }
    public bool SaveUserFile(string filepath)
    {
        // write name and points
        string toWrite;
        using (StreamWriter outputFile = new StreamWriter(filepath))
        {
            outputFile.WriteLine($"User||{_name}||{_points}");
            foreach (Goal g in _goals)
            {

                if (g is EternalGoal)
                {
                    toWrite = "EternalGoal||";
                }
                else if (g is ChecklistGoal)
                {
                    toWrite = "ChecklistGoal||";
                }
                else if (g is Goal)
                {
                    toWrite = "Goal||";
                }
                else
                {
                    //you did something wrong if you end up here
                    toWrite = "Unknown||";
                }
                toWrite += g.GoalToString();
                outputFile.WriteLine(toWrite);
            }
        }
        return true; // thought I would need to have the status returned, maybe not though
    }
    public void AddNewGoal(Goal newGoal)
    {
        _goals.Add(newGoal);
    }
    public int GetPoints()
    {
        return _points;
    }
    public string GetName()
    {
        return _name;
    }
    public void SetupNewUser()
    {
        Console.WriteLine("What is your name?");
        _name = Console.ReadLine();
        Console.Write($"Hi {_name}!");
        _points = 0;
    }
    public void Autosave()
    {
        SaveUserFile("autosave.txt");
    }
    public void ListGoals(bool numbers)
    {
        Console.WriteLine("----- Goals -----");
        int count = 1;
        foreach (Goal g in _goals)
        {
            if (numbers)
            {
                Console.Write(count.ToString().PadLeft(2) + ". ");
            }
            else
            {
                Console.Write("   ");
            }
            g.PrintGoalDetails();
            count++;
        }
    }
    public int CompleteAGoal()
    {
        int pointsGain;
        ListGoals(true); // list with numbers
        Console.WriteLine($"Which Goal did you complete? (or pick {_goals.Count() + 1} to cancel): ");
        int menuChoice = int.Parse(Console.ReadLine());
        if (menuChoice >= 1 && menuChoice <= _goals.Count())
        {
            pointsGain = _goals[menuChoice - 1].CompleteGoalGetPoints();
            _points += pointsGain;
            Console.Clear();
            if (pointsGain == 0)
            {
                // no goal was completed
                Console.Write($"Sorry, that goal was already completed.");
            }
            else
            {
                Console.Write($"Nice job! you got {pointsGain} points!");
            }
            return pointsGain;
        }
        else
        {
            Console.Clear();
            return 0;
        }
    }
}