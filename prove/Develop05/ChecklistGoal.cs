class ChecklistGoal : Goal
{
    private int _totalSteps;
    private int _currentStep;
    private int _stepReward;

    public ChecklistGoal(string name, string desc, string reward, string goalComplete, string totalSteps, string stepsCompleted, string stepReward) : base(name, desc, reward, goalComplete)
    {
        _totalSteps = int.Parse(totalSteps);
        _currentStep = int.Parse(stepsCompleted);
        _stepReward = int.Parse(stepReward);
    }
    public ChecklistGoal()
    {
        Console.WriteLine("How many steps will this goal have?:");
        _totalSteps = int.Parse(Console.ReadLine());
        Console.WriteLine("How many points is each step worth?:");
        _stepReward = int.Parse(Console.ReadLine());
    }
    public override int CompleteGoalGetPoints()
    {
        if (!_isGoalComplete)
        {
            if (_currentStep == _totalSteps - 1) // if you've just completed the last one (eg you're at 2/3 and complete one more)
            {
                _currentStep++;
                _isGoalComplete = true;
                return _reward + _stepReward;
            }
            else // if you're just completing one along the way
            {
                _currentStep++;
                return _stepReward;
            }
        }
        else
        {
            return 0;
        }
    }
    public override void PrintGoalDetails()
    {
        Console.Write($"{_name.PadRight(15)} | {_description.PadRight(25)} | {(_stepReward.ToString() + " points").PadLeft(11)} | ");
        if (_isGoalComplete)
        {
            Console.Write("[X]");
        }
        else
        {
            Console.Write("[ ]");
        }
        Console.WriteLine($" | Checklist | {_currentStep}/{_totalSteps} times | {_reward} point bonus");
    }

    public override string GoalToString() // for writing objects into files
    {
        //process goal into string
        return _name + "||" + _description + "||" + _reward + "||" + _isGoalComplete + "||" + _totalSteps + "||" + _currentStep + "||" + _stepReward;
    }
}