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
        Console.WriteLine($"\n\nThanks for coming to this {_activityName} activity! {_descrption} It will last for {_duration} seconds. Get ready and we'll start soon.");
        dotsGoBrrr(7);
        Console.Clear();
    }
    protected void showEnding()
    {
        Console.Write("\nNice Job! ");
        showSpinner(3);
        Console.Write($"\nThanks for coming to the {_activityName} activity! This activity lasted {_duration} seconds. ");
        showSpinner(6);
        Console.WriteLine("\n\nPress Enter to continue...");
        Console.ReadLine(); // wait for user to hit enter
        Console.Clear();
    }

    protected void dotsGoBrrr(int duration) // duration in seconds
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
    }

    protected void showSpinner(int duration) //duration in seconds
    {
        duration *= 4;
        List<char> spinnerBits = new List<char> { '|', '/', '-', '\\'};
        int spinnerIndex = 0;
        while (duration > 0)
        {
            Console.Write(spinnerBits[spinnerIndex]);
            Thread.Sleep(250);
            Console.Write("\b");
            spinnerIndex++;
            if (spinnerIndex == 4)
                spinnerIndex = 0;
        }
        Console.Write(" ");


    }
}