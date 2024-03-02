using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Welcome to Mindfulness! Pick an option:");
        while (true)
        {
            Console.WriteLine("1. Breathing activity");
            Console.WriteLine("2. Reflection activity");
            Console.WriteLine("3. Listing activity");
            Console.WriteLine("4. Quit");
            int menuChoice, duration = 0;
            makeMenuChoice:
            menuChoice = int.Parse(Console.ReadLine());
            if (menuChoice < 4) // if an activity is picked, ask how long to make it
            {
                Console.WriteLine("How long would you like it to last? (in seconds): ");
                duration = int.Parse(Console.ReadLine());
            }
            switch (menuChoice)
            {
                case 1: // breathing activity
                    BreathingActivity breathe = new BreathingActivity("Breathing", "Learn how to breathe here.", duration);
                    break;
                case 2: // Reflection activity
                    ReflectionActivity reflect = new ReflectionActivity("Reflection", "Reflect on you life and feel better.", duration);
                    break;
                case 3: // Listing activity
                    ListingActivity list = new ListingActivity("Listing", "List things to remember better.", duration);
                    break;
                case 4: // quitting activity
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Pick a number between 1 and 4 you silly goose");
                    goto makeMenuChoice;
            }
            
            Console.WriteLine("That was nice! What else would you like to do?");
        }

    }
}