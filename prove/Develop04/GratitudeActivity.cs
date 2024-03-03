class GratitudeActivity : Activity
{
    private int _numGratitudes = 0;
    public GratitudeActivity(string name, string desc, int duration) : base(name, desc, duration)
    {
        // see Activity class
    }

    protected override void StartActivity() // this will run once
    {
        Console.Write($"Write everything you are grateful for regarding your {RandomGratitudeTopic()} for the next {_duration} seconds:");
        ShowSpinner(5);
        Console.Write("\nYou may begin in ");
        ShowCountdown(5);
        Console.Write("\n"); // newline so it looks nice

    }
    protected override void RunActivity() // this will run on loop until time is up
    {
        Console.Write("-");
        Console.ReadLine();
        _numGratitudes++;
    }
    protected override void EndActivity()
    {
        Console.WriteLine($"\nTimes up! Total gratitudes: {_numGratitudes}");
        Console.WriteLine("Bonus: go back and look through what you wrote.");
    }

    private string RandomGratitudeTopic()
    {
        List<string> gratitudeTopics = new List<string>();
        gratitudeTopics.Add("relationships");
        gratitudeTopics.Add("family");
        gratitudeTopics.Add("school work");
        gratitudeTopics.Add("hobbies and pursuits");
        gratitudeTopics.Add("home life");
        gratitudeTopics.Add("roommates");
        gratitudeTopics.Add("experiences");
        gratitudeTopics.Add("community");
        gratitudeTopics.Add("opportunities");
        gratitudeTopics.Add("health");
        gratitudeTopics.Add("friends");
        
        Random random = new Random();
        int randomIndex = random.Next(0, gratitudeTopics.Count);
        string randomString = gratitudeTopics[randomIndex];
        return randomString;
    }
}
