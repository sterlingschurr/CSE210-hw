class Goal
{
    protected string _name;
    protected string _description;
    protected int _reward;
    protected bool _isGoalComplete;
    public Goal(string name, string desc, string reward, string goalComplete) // for loading from file
    {
        _name = name;
        _description = desc;
        _reward = int.Parse(reward);
        _isGoalComplete = bool.Parse(goalComplete);

    }
    public Goal()
    {
        _isGoalComplete = false;
        Console.WriteLine("What is the name of the goal?:");
        _name = Console.ReadLine();
        Console.WriteLine("What is a short description of the goal?:");
        _description = Console.ReadLine();
        Console.WriteLine("How many points is completing the goal worth?:");
        _reward = int.Parse(Console.ReadLine());
    }
    public virtual int CompleteGoalGetPoints()
    {
        if (!_isGoalComplete)
        {
            _isGoalComplete = true;
            return _reward;
        }
        else
        {
            return 0;
        }

    }
    public virtual string GoalToString() // for writing objects into files
    {
        //process goal into string
        return _name + "||" + _description + "||" + _reward + "||" + _isGoalComplete;
    }
    public virtual void PrintGoalDetails()
    {
        Console.Write($"{_name.PadRight(15)} | {_description.PadRight(25)} | {(_reward.ToString() + " points").PadLeft(11)} | ");
        if (_isGoalComplete)
        {
            Console.Write("[X]");
        }
        else
        {
            Console.Write("[ ]");
        }
        Console.WriteLine(" | Normal");
    }
}