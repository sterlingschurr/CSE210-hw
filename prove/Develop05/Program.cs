using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hello! This is the goals program.");
        bool validUser = false;
        User you = new User();

        //----------------startup menu loop-------------------

        while (!validUser) // don't exit loop until a valid menu item has been picked and a user has been found/created
        {
            Console.WriteLine("1. Load autosave");
            Console.WriteLine("2. Make new user");
            Console.WriteLine("3. Enter user filepath");
            Console.WriteLine("4. Quit");
            Console.Write("Pick an option: ");
            int menuChoice;
            menuChoice = int.Parse(Console.ReadLine());
            switch (menuChoice)
            {
                case 1: //1. Load autosave
                    if (you.LoadUserFile("autosave.txt"))
                        validUser = true;
                    break;

                case 2: // 2. Make new user
                    you.SetupNewUser();
                    validUser = true;
                    break;

                case 3: // 3. Enter user file
                    Console.WriteLine("What is the file name?:");
                    string filepath = Console.ReadLine();
                    if (you.LoadUserFile(filepath))
                        validUser = true;
                    break;

                case 4: //  Quit
                    Console.WriteLine("seeya");
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Pick a number between 1 and 4 you silly goose");
                    break;
            }
        }

        // ------------- main menu loop ---------------
        Console.Clear();
        bool quit = false;
        Console.Write($"Hi {you.GetName()}!");
        while (!quit)
        {
            Console.WriteLine($" - You have {you.GetPoints()} points.\n");
            Console.WriteLine("1. New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save to file");
            Console.WriteLine("4. Load from file");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Pick an option: ");
            int menuChoice;
            string filepath;
            menuChoice = int.Parse(Console.ReadLine());
            switch (menuChoice)
            {
                case 1: //1. New Goal
                    Console.Clear();
                    Console.WriteLine("--- Make a new Goal ---");
                    Console.WriteLine("1. Normal Goal");
                    Console.WriteLine("2. Eternal Goal");
                    Console.WriteLine("3. Checklist Goal");
                    Console.WriteLine("4. Go back");
                    menuChoice = int.Parse(Console.ReadLine());
                    Goal tempGoal;
                    switch (menuChoice)
                    {
                        case 1:
                            tempGoal = new Goal();
                            you.AddNewGoal(tempGoal);
                            Console.Clear();
                            Console.Write("Goal Created");
                            break;
                        case 2:
                            tempGoal = new EternalGoal();
                            you.AddNewGoal(tempGoal);
                            Console.Clear();
                            Console.Write("Eternal Goal Created");

                            break;
                        case 3:
                            tempGoal = new ChecklistGoal();
                            you.AddNewGoal(tempGoal);
                            Console.Clear();
                            Console.Write("Checklist Goal Created");
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
                    you.Autosave();
                    break;

                case 2: // 2. List Goals
                    Console.Clear();
                    you.ListGoals(false); // list with no numbers
                    Console.WriteLine("1. Record an event");
                    Console.WriteLine("2. Go back");
                    menuChoice = int.Parse(Console.ReadLine());
                    Console.Clear();
                    if (menuChoice == 1)
                    {
                        you.CompleteAGoal();
                    }
                    break;

                case 3: //3. Save to file
                    Console.WriteLine("What file name to save it under?:");
                    filepath = Console.ReadLine();
                    if (filepath == "autosave.txt")
                    {
                        Console.WriteLine("Sorry, autosave.txt is reserved for the autsaving function.");
                    }
                    else
                    {
                        if (you.SaveUserFile(filepath))
                        {
                            Console.Clear();
                            Console.Write("Saving user success!");
                        }
                        else
                        {
                            Console.Write("Saving user failed");
                        }
                    }
                    break;

                case 4: //  4. Load from file
                    Console.WriteLine("What is the file name? (or type autosave.txt if you want to load the autosave):");
                    filepath = Console.ReadLine();
                    if (!you.LoadUserFile(filepath))
                    {
                        Console.WriteLine("Loading user failed");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Loading user success!");
                        Console.Write($"Hi {you.GetName()}!");
                    }
                    break;

                case 5: // 5. Record Event
                    Console.Clear();
                    you.CompleteAGoal();
                    you.Autosave();
                    break;

                case 6: // 6. Quit
                    Console.WriteLine("seeya");
                    quit = true;
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Pick a number between 1 and 6 you silly goose");
                    break;
            }
        }
    }
}