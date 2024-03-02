using System.Runtime.CompilerServices;

class ReflectionActivity : Activity
{
    public ReflectionActivity(string name, string desc, int duration) : base(name, desc, duration)
    {
        Console.Write($"Here is your prompt to ponder on for a moment:\n\n{randomPonderPrompt()}\n\n");
        DateTime endTime = DateTime.Now.AddSeconds(duration); // make a time in the future
        while (DateTime.Now < endTime) // while it is not yet that time (activity still going)
        {
            Console.Write($"And here is a question to help reflect on that:\n\n {randomQuestionPrompt()}");
            dotsGoBrrr(15);
        }
        showEnding();
    }

    

    private string randomPonderPrompt()
    {
        List<string> ponderPrompts = new List<string>();
        ponderPrompts.Add("Think of a time when you did something truly selfless.");
        ponderPrompts.Add("Think of a time when you helped someone in need.");
        ponderPrompts.Add("Think of a time when you did something really difficult.");
        ponderPrompts.Add("Think of a time when you stood up for someone else.");
        Random random = new Random();
        int randomIndex = random.Next(0, ponderPrompts.Count);
        string randomString = ponderPrompts[randomIndex];
        return randomString;

    }
    private string randomQuestionPrompt()
    {
        List<string> questionPrompts = new List<string>();
        questionPrompts.Add("How can you keep this experience in mind in the future?");
        questionPrompts.Add("What did you learn about yourself through this experience?");
        questionPrompts.Add("What could you learn from this experience that applies to other situations?");
        questionPrompts.Add("What is your favorite thing about this experience?");
        questionPrompts.Add("What made this time different than other times when you were not as successful?");
        questionPrompts.Add("How did you feel when it was complete?");
        questionPrompts.Add("How did you get started?");
        questionPrompts.Add("Have you ever done anything like this before?");
        questionPrompts.Add("Why was this experience meaningful to you?");

        Random random = new Random();
        int randomIndex = random.Next(0, questionPrompts.Count);
        string randomString = questionPrompts[randomIndex];
        return randomString;
    }
}