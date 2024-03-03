using System.Runtime.CompilerServices;

class ReflectionActivity : Activity
{
    public ReflectionActivity(string name, string desc, int duration) : base(name, desc, duration)
    {
        // see Activity class
    }

    protected override void StartActivity() // this will run once
    {
        Console.Write($"Here is your prompt to ponder on:\n\n---- {RandomPonderPrompt()} ----\n\n");
        Console.Write("Press Enter when you've got it...");
        Console.ReadLine(); // wait for user to hit enter
        Console.Write($"While you reflect on this experience, answer these questions:");
        ShowSpinner(3);
    }
    protected override void RunActivity() // this will run on loop until time is up
    {
        Console.Write("\n- " + RandomQuestionPrompt());
        ShowSpinner(15);
    }


    private string RandomPonderPrompt()
    {
        List<string> ponderPrompts = new List<string>();
        ponderPrompts.Add("Think of a time when you did something truly selfless.");
        ponderPrompts.Add("Think of a time when you helped someone in need.");
        ponderPrompts.Add("Think of a time when you did something really difficult.");
        ponderPrompts.Add("Think of a time when you stood up for someone else.");
        ponderPrompts.Add("Consider a time when you had to adapt to a significant change in your life.");
        ponderPrompts.Add("Reflect on a memorable journey or adventure you embarked on.");
        ponderPrompts.Add("Remember a time when you felt deeply connected to someone or something.");
        ponderPrompts.Add("Reflect on a time when you faced and overcame a fear.");
        ponderPrompts.Add("Recall a moment when you felt immense pride in an accomplishment.");
        Random random = new Random();
        int randomIndex = random.Next(0, ponderPrompts.Count);
        string randomString = ponderPrompts[randomIndex];
        return randomString;

    }
    private string RandomQuestionPrompt()
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
        questionPrompts.Add("Did this experience inspire you to take any new actions or pursue different paths in the future?");
        questionPrompts.Add("How did others perceive your involvement or actions during this experience?");
        questionPrompts.Add("What surprised you most about the outcome of this experience?");
        questionPrompts.Add("Did this experience change your perspective on anything?");
        questionPrompts.Add("How did this experience align with your values or beliefs?");

        Random random = new Random();
        int randomIndex = random.Next(0, questionPrompts.Count);
        string randomString = questionPrompts[randomIndex];
        return randomString;
    }
}