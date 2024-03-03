class ListingActivity : Activity
{
    private int _numListItems = 0;
    public ListingActivity(string name, string desc, int duration) : base(name, desc, duration)
    {
        // see Activity class
    }
    protected override void StartActivity() // this will run once
    {
        Console.WriteLine($"Here is your prompt! List everything you can think of to answer the question for the next {_duration} seconds:\n");
        Console.Write(RandomListingPrompt());
        ShowSpinner(4);
        Console.Write("\nYou may begin in ");
        ShowCountdown(5);
        Console.Write("\n"); // newline so it looks nice

    }
    protected override void RunActivity() // this will run on loop until time is up
    {
        Console.Write(">");
        Console.ReadLine();
        _numListItems++;
    }
    protected override void EndActivity()
    {
        Console.WriteLine($"\nTotal items listed: {_numListItems}");
        Console.WriteLine("Feel free to scroll back through them");
    }


    private string RandomListingPrompt()
    {
        List<string> reflectionPrompts = new List<string>();
        reflectionPrompts.Add("Who are some of your personal heroes?");
        reflectionPrompts.Add("When have you felt the Holy Ghost this month?");
        reflectionPrompts.Add("Who are people that you have helped this week?");
        reflectionPrompts.Add("What are personal strengths of yours?");
        reflectionPrompts.Add("Who are people that you appreciate?");
        Random random = new Random();
        int randomIndex = random.Next(0, reflectionPrompts.Count);
        string randomString = reflectionPrompts[randomIndex];
        return randomString;
    }
}