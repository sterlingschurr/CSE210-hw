using System;

class Program
{
    static void Main(string[] args)
    {

        bool quit = false;
        PromptGenerator promGen = new PromptGenerator();
        promGen._promptFilePath = "prompts.txt";
        promGen.LoadPromptsFromFile();
        promGen.DisplayAllPrompts();


        promGen.GetRandomPrompt();
        Journal journal = new Journal();
        while (!quit)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Make an Entry"); Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Load journal from a file"); Console.WriteLine("4. Save journal to a file");
            Console.WriteLine("5. Add a prompt for later"); Console.WriteLine("6. Quit");
            int menuChoice = 0;
            menuChoice = int.Parse(Console.ReadLine());

            switch (menuChoice)
            {
                case 1: //"1. Make an Entry"

                    Entry entry = new Entry();
                    entry._promptText = promGen.GetRandomPrompt();
                    Console.WriteLine("Here is your writing prompt, Write your entry below it:");
                    Console.WriteLine(entry._promptText);
                    entry._entryText = Console.ReadLine();
                    journal.AddEntry(entry);

                    break;
                case 2: //2. Display journal
                    journal.DisplayAll();
                    break;
                case 3: //"3. Load journal from a file
                    Console.WriteLine("What is the filepath for your journal?");
                    journal.LoadFromFile(Console.ReadLine());
                    break;
                case 4: //4. Save journal to a file
                    Console.WriteLine("What is the filepath we are saving to?");
                    journal.SaveToFile(Console.ReadLine());
                    break;
                case 5: //5. Add a prompt for later
                    Console.WriteLine("\nWhat would you like your prompt to say? Write it below:");
                    promGen.AddPrompt(Console.ReadLine());
                    break;
                case 6: //6. Quit
                    quit = true;
                    Console.WriteLine("Goodbye");

                    break;
                default:
                    Console.WriteLine("Input a number between 1 and 5");
                    break;
            }

        }
    }
}