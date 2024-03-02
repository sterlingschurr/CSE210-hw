class BreathingActivity : Activity
{
    public BreathingActivity(string name, string desc, int duration) : base(name, desc, duration)
    {
        
        Console.WriteLine("Get ready to breathe in, starting in ");
        countDown(3);
        DateTime endTime = DateTime.Now.AddSeconds(duration); // make a time in the future
        while (DateTime.Now < endTime) // while it is not yet that time (activity still going)
        {
            Console.Write("\nBreathe in... ");
            countDown(5);
            Console.Write("\nHold it... ");
            countDown(3);
            Console.Write("\nBreathe out... ");
            countDown(5);
            Console.Write("\nHold it... ");
            countDown(3);
        }
        showEnding();
    }

    private void countDown(int length) // input length in seconds
    {
        length = Math.Abs(length); // no negative numbers
        while (length > 0)
        {
            Console.Write(length);
            if (length < 10)
                Console.Write(" ");
            Thread.Sleep(1000);
            Console.Write("\b\b");
            length -= 1;
        }
        //Console.Write("\b\b");
        Console.Write("  ");
    }
}