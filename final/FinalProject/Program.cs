using System;

class Program
{
    static void Main(string[] args)
    {


        List<string> bootMenuChoices = new List<string>() { "Load a specific inventory", "Make a new inventory", "Exit" };

        //if autosave file exists
        Console.WriteLine("Previous inventory detected!");
        bootMenuChoices.Add("Load previous inventory"); // this adds a menu option

        Inventory inv = new Inventory();
        switch (inv.MenuChoiceHandler(bootMenuChoices))
        {
            case 1: // load specific
                //prompt for a filename
                break;
            case 2: // make new
                //prompt for a name of the file to save under
                break;
            case 3: // exit
                Environment.Exit(0);
                break;
            case 4: // load previous (the handler won't return this unless a fourth thing was added to the list)
                // load the autosave file
                break;
        }

        List<string> mainMenuChoices = new List<string>() { "Check out an item", "Check in an item", "Add a user", "Manage Inventory", "Manage save files", "Exit" };
        while (true)
        {
            switch (inv.MenuChoiceHandler(mainMenuChoices))
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
            }
        }
    }

}