using System;

class Program
{
    static void Main(string[] args)
    {


        List<string> bootMenuChoices = new List<string>() { "Load a specific inventory", "Make a new inventory" };
        if (File.Exists("autosave.txt"))
        {
            Console.WriteLine("Previous inventory detected!");
            bootMenuChoices.Add("Load autosaved inventory"); // this adds a menu option
        }
        bootMenuChoices.Add("Exit");

        Inventory inv = new Inventory();



        switch (inv.MenuChoiceHandler(bootMenuChoices))
        {
            case "Load a specific inventory": // load specific
                Console.WriteLine("Which file would you like to load?");
                inv.LoadFromFile(Console.ReadLine());
                //prompt for a filename
                break;
            case "Make a new inventory": // make new
                Console.WriteLine("What would you like to name the new file?");
                inv.SaveToFile(Console.ReadLine());
                //prompt for a name of the file to save under
                break;
            case "Exit": // exit
                Environment.Exit(0);
                break;
            case "Load autosaved inventory": // load previous (the handler won't return this choice unless a fourth thing was added to the list)
                inv.LoadFromFile();
                break;
        }

        List<string> mainMenuChoices = new List<string>() { "Check out an item", "Check in an item", "View late checkouts", "Manage Inventory/Users", "Save/Load", "Exit" };
        while (true) // main program loop
        {
            inv.SaveToFile(); // autosave
            switch (inv.MenuChoiceHandler(mainMenuChoices))
            {
                case "Check out an item": // check out
                    List<string> checkoutMenuChoices = new List<string>() { "All items", "Cameras", "Tripods", "Projectors", "Cancel" };
                    switch (inv.MenuChoiceHandler(checkoutMenuChoices, "Which type of item? "))
                    {
                        case "All items":
                            inv.CheckItem(true, "all");
                            break;
                        case "Cameras":
                            inv.CheckItem(true, "camera");
                            break;
                        case "Tripods":
                            inv.CheckItem(true, "tripod");
                            break;
                        case "Projectors":
                            inv.CheckItem(true, "projector");
                            break;
                        default: // go back
                            break;
                    }
                    break;
                case "Check in an item":
                    inv.CheckItem(false); // false means checking in an item
                    break;
                case "View late checkouts":
                    inv.PrintLateCheckouts();
                    break;
                case "Manage Inventory/Users": // manage
                    List<string> manageMenuChoices = new List<string>() { "View all items", "View all users", "View checkouts by user", "Add a user", "Add Item", "Go Back" };
                    switch (inv.MenuChoiceHandler(manageMenuChoices))
                    {
                        case "Add a user":
                            User newUser = new User();
                            newUser.SetID(inv.GetNewIDNumber());
                            Console.WriteLine($"Their new ID number is {newUser.GetID()}");
                            inv.AddUser(newUser);
                            Thread.Sleep(3000);
                            break;
                        case "View all items":
                            inv.printAllItems();
                            break;
                        case "View all users":
                            inv.printAllUsers();
                            break;
                        case "View checkouts by user":
                            Console.Clear();
                            bool foundSomething = false;
                            foreach (User u in inv.GetUserList()) // go through each user
                            {
                                if (u.GetOpenCheckoutIDs().Any()) // if that user has any checkouts
                                {
                                    Console.WriteLine($"{u.GetFirstName()} {u.GetLastName()} - Checkouts: {u.GetOpenCheckoutIDs().Count()}");
                                    foreach (int ID in u.GetOpenCheckoutIDs()) // look up each item and print it
                                    {
                                        Console.WriteLine(inv.ItemFromID(ID).GetPrintableData());
                                        foundSomething = true; // we found something
                                    }
                                    Console.WriteLine();
                                }
                            }
                            if (!foundSomething)
                            {
                                Console.WriteLine("No checkouts found!");
                                Thread.Sleep(3000);
                            }
                            else
                            {
                                Console.WriteLine("Press Enter to continue...");
                                Console.ReadLine();
                            }
                            break;
                        case "Remove a user":
                            break;
                        case "Add Item":
                            List<string> newItemMenuChoices = new List<string>() { "Generic", "Camera", "Tripod", "Projector", "Go Back" };
                            switch (inv.MenuChoiceHandler(newItemMenuChoices))
                            {
                                case "Generic":
                                    Item newItem = new Item();
                                    newItem.SetID(inv.GetNewIDNumber());
                                    inv.AddItem(newItem);
                                    break;
                                case "Camera":
                                    ItemCamera newItemCamera = new ItemCamera();
                                    newItemCamera.SetID(inv.GetNewIDNumber());
                                    inv.AddItem(newItemCamera);
                                    break;
                                case "Tripod":
                                ItemTripod newItemTripod = new ItemTripod();
                                    newItemTripod.SetID(inv.GetNewIDNumber());
                                    inv.AddItem(newItemTripod);
                                    break;
                                case "Projector":
                                ItemProjector newItemProjector = new ItemProjector();
                                    newItemProjector.SetID(inv.GetNewIDNumber());
                                    inv.AddItem(newItemProjector);
                                    break;
                                default: // go back
                                    break;
                            }


                            break;
                        case "Remove Item":
                            break;
                        default:
                            break;

                    }

                    break;
                case "Save/Load": // save and load
                    List<string> saveLoadMenuChoices = new List<string>() { "Save to file", "Load from file", "Load the autosave", "Go back" };
                    switch (inv.MenuChoiceHandler(saveLoadMenuChoices))
                    {
                        case "Save to file": // save
                            Console.WriteLine("What file would you like to save to?");
                            inv.SaveToFile(Console.ReadLine());
                            break;
                        case "Load from file": // load
                            Console.WriteLine("What file would you like to load from?");
                            inv.LoadFromFile(Console.ReadLine());
                            break;
                        case "Load the autosave":
                            inv.LoadFromFile(); // defaults to autosave.txt
                            break;
                        default: // go back
                            break;
                    }
                    break;
                case "Exit": // quit
                    Environment.Exit(0);
                    break;
            }
        }
    }
}