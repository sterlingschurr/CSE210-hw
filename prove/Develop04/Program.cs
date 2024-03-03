using System;

class Program
{
    // -----EXTRA THINGS I DID-----
    //Made a new gratitude activity
    // added extra prompts beyond the provided for listing and reflection activities
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to Mindfulness!");
        while (true)
        {
            Console.WriteLine("1. Breathing activity");
            Console.WriteLine("2. Reflection activity");
            Console.WriteLine("3. Listing activity");
            Console.WriteLine("4. Gratitude activity");
            Console.WriteLine("5. Quit");
            Console.Write("Pick an option: ");
            int menuChoice, duration = 0;
            menuChoice = int.Parse(Console.ReadLine());
            if (menuChoice < 6 && menuChoice > 0) // if valid input
            {
                if (menuChoice != 5) // if not quitting, ask how long to make the activity
                {
                    Console.Write("\nHow long would you like it to last? (in seconds): ");
                    duration = int.Parse(Console.ReadLine());
                }

                switch (menuChoice)
                {
                    case 1: // Breathing activity
                        BreathingActivity breathe = new BreathingActivity("breathing", "Engage in this activity to unwind, guiding you through slow, deliberate breaths. Empty your mind and concentrate solely on your breath.", duration);
                        break;
                    case 2: // Reflection activity
                        ReflectionActivity reflect = new ReflectionActivity("reflection", "This activity aids in reflecting on moments of strength and resilience in your life, empowering you to recognize and leverage your personal power across various domains.", duration);
                        break;
                    case 3: // Listing activity
                        ListingActivity list = new ListingActivity("listing", "This activity encourages reflection on the positive aspects of your life by prompting you to list as many things as possible on a specific topic.", duration);
                        break;
                    case 4: // Gratitude activity
                        GratitudeActivity gratitude = new GratitudeActivity("gratitude", "This activity helps you come up with things you're grateful for by focusing on specific areas of your life.", duration);
                        break;
                    case 5: // Quitting activity
                        Console.WriteLine("byeeeeee");
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("That was nice! What else would you like to do?"); // after activity have a come back message because that's nice
            }
            else // if they don't pick between 1 and 5
            {
                Console.WriteLine("Pick a number between 1 and 5 you silly goose");
            }


        }

    }
}