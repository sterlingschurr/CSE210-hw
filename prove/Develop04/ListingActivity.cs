class ListingActivity : Activity
{
    public ListingActivity(string name, string desc, int duration) : base(name, desc, duration)
    {
        showSpinner(10);
    }

    private string randomListingPrompt()
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