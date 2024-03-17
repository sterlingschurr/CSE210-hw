class EternalGoal : Goal
{
    public EternalGoal(string name, string desc, string reward, string goalComplete) : base(name, desc, reward, goalComplete)
    {
        // not sure why i need this but there are errors if I don't
    }
    public EternalGoal()
    {
        // not sure why i need this but there are errors if I don't
    }
    public override int CompleteGoalGetPoints()
    {
        // don't check off because eternal goal never ends
        return _reward;
    }
    public override void PrintGoalDetails()
    {
        Console.WriteLine($"{_name.PadRight(15)} | {_description.PadRight(25)} | {(_reward.ToString() + " points").PadLeft(11)} | Eternal ");
    }
}