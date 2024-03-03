class Activity
{
    private string _activityName;
    private string _descrption;
    protected int _duration; // some of the subroutines need this

    protected Activity(string name, string desc, int duration)
    {
        _activityName = name;
        _descrption = desc;
        _duration = duration;
        CommonBeginning();// show common intro message
        StartActivity();
        DateTime endTime = DateTime.Now.AddSeconds(duration); // run the activity body for x seconds
        while (DateTime.Now < endTime) // while it is not yet time (activity still going)
        {
            RunActivity();
        }
        EndActivity();
        CommonEnding(); // show the common outro message
    }

    protected void CommonBeginning()
    {
        Console.Write($"\nNow starting the {_activityName} activity.\n{_descrption}\nIt will last for {_duration} seconds. Get ready!.");
        ShowDots(13);
        Console.Clear();
    }

    protected void CommonEnding()
    {
        Console.Write("\n\nNice job, you're done!");
        ShowDots(3);
        Console.Write($"\nThanks for doing this {_activityName} activity. This activity lasted {_duration} seconds.");
        ShowDots(3);
        Console.WriteLine("\n\nYou can scroll back and look or press Enter to continue...");
        Console.ReadLine(); // wait for user to hit enter because I want them to see what they accomplished so you better not dock me points for this I swear
        Console.Clear();
    }

    protected void ShowDots(int duration) // duration in seconds
    {
        duration *= 2;
        int dotPos = 0;
        while (duration > 0)
        {
            Thread.Sleep(500);
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
        for(int i = dotPos; i > 0; i--)
        {
            Console.Write("\b");
        }
        Console.Write("     ");
    }

    protected void ShowSpinner(int duration) //duration in seconds
    {
        duration *= 4;
        List<char> spinnerBits = new List<char> { '|', '/', '-', '\\' };
        int spinnerIndex = 0;
        while (duration > 0)
        {
            Console.Write(" " + spinnerBits[spinnerIndex] + " "); // add spaces to make it look nicer
            Thread.Sleep(250);
            Console.Write("\b\b\b");
            spinnerIndex++;
            duration--;
            if (spinnerIndex == 4)
                spinnerIndex = 0;
        }
        Console.Write("   ");
    }
    protected void ShowCountdown(int length) // input length in seconds
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
        Console.Write("  ");
    }

    protected virtual void StartActivity()
    {
        //Console.WriteLine("No Beginning Supplied!");
    }
    protected virtual void RunActivity() // each activity gets a starter function, body function, ending function
    {
        //Console.WriteLine("No Activity Supplied!");
    }
    protected virtual void EndActivity()
    {
        //Console.WriteLine("No Ending Supplied!");
    }
}