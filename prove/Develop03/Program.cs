using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Library lib = new Library();
        Scripture script = new Scripture();
        script.ParseLibEntry(lib.GetRandomEntry());

        bool keepGoing = false;
        while (!keepGoing)
        {
            Console.WriteLine("This is the scripture we will be memorizing: ");
            script.PrintScripture();
            Console.WriteLine("\nIs that okay? Press enter to continue, type 'new' for a different scripture, or 'quit' to quit ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "":
                    keepGoing = true;
                    break;
                case "new":
                    Console.Clear();
                    Console.WriteLine(".................Okay, Let's pick a different one.................");
                    script.ParseLibEntry(lib.GetRandomEntry());
                    break;
                case "quit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Sorry, that wasn't one of the choices, try again");
                    break;


            }
        }
        bool gameOver = false;
        int hideChance = 10;
        while (!gameOver)
        {
            Console.Clear();
            script.PrintScripture();
            if (script.AreAllWordsHidden())
            {
                Console.WriteLine("\nCongrats, you did it! Press any key to exit...");
                Console.ReadKey();
                gameOver = true;
            }
            else
            {
                Console.WriteLine("\n\nPress enter to hide more words, or type quit to exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "quit":
                        gameOver = true;
                        break;
                    default:
                        break;
                }
                script.HideMoreWords(hideChance);
                hideChance += 5;
            }
        }
    }
}