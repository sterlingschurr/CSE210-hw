class Activity
{
    private string _activityName;
    private string _descrption;
    private int _duration;

    protected Activity(string name, string desc, int duration)
    {
        _activityName = name;
        _descrption = desc;
        _duration = duration;
        Console.WriteLine($"\n\nThanks for coming to this {_activityName} activity! {_descrption} This activity will last for {_duration} seconds. We'll get goin here shortly");
        dotsGoBrrr(6);
    }
    protected void showEnding()
    {
        Console.WriteLine($"Thanks for coming to this {_activityName} activity! {_descrption} This activity lasted {_duration} seconds.");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    protected void dotsGoBrrr(int duration) // duration in seconds
    {
        duration *= 3;
        int dotPos = 0;
        while (duration > 0)
        {
            Thread.Sleep(333);
            Console.Write(".");
            dotPos++;
            duration--;
            if (dotPos == 4)
            {
                dotPos = 0;
                Console.Write("\b\b\b\b");
                Console.Write("    ");
                Console.Write("\b\b\b\b");
            }

        }
    }
}