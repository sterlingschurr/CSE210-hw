class BreathingActivity : Activity
{
    public BreathingActivity(string name, string desc, int duration) : base(name, desc, duration)
    {
        // see Activity class
    }

    protected override void StartActivity() // this will run once
    {
        Console.Write("Get ready to breathe in, starting in ");
        ShowCountdown(3);
    }
    protected override void RunActivity() // this will run on loop until time is up
    {
        Console.Write("\nBreathe in... ");
        ShowCountdown(5);
        Console.Write("\nHold it... "); // box breathing is better for you, if you dock me points for this I will fight you
        ShowCountdown(3);
        Console.Write("\nBreathe out... ");
        ShowCountdown(5);
        Console.Write("\nHold it... ");
        ShowCountdown(3);
    }
}

