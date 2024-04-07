using System.Runtime.InteropServices;
using System.Xml;

class Inventory
{
    private List<User> _users = new List<User>();
    private List<Item> _items = new List<Item>();

    public void AddItem(Item item) { _items.Add(item); }
    public void AddUser(User user) { _users.Add(user); }
    public List<User> GetUserList() { return _users; }
    public void printAllItems()
    {
        Console.Clear();
        foreach (Item i in _items)
        {
            Console.WriteLine(i.GetPrintableData());
        }
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
    public void printAllUsers()
    {
        Console.Clear();
        foreach (User u in _users)
        {
            Console.WriteLine(u.GetPrintableData());
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
    public void PrintLateCheckouts()
    {
        bool foundSomething = false;
        Console.Clear();
        foreach (Item i in _items)
        {
            if ((i.GetDueBackTime() < DateTime.Now) && i.IsCheckedOut())
            {
                Console.WriteLine(i.GetPrintableData());
                foundSomething = true;
            }
        }
        if (foundSomething)
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("No late checkouts found!");
            Thread.Sleep(3000);
        }
    }
    public Item ItemFromID(int ID, int mode = 0, int checkeeID = 0) // mode 0 is get, mode 1 is check out, mode 2 is check in
    {
        foreach (Item i in _items)
        {
            if (i.GetID() == ID)
                if (mode == 0) // get
                    return i;
                else if (mode == 1) // check out
                {
                    i.CheckOut();
                    i.SetCheckeeID(checkeeID);
                }
                else if (mode == 2) // check in
                    i.CheckIn();
        }
        //Console.WriteLine("There is no item with that ID!");
        Item temp = new Item(-1); // dummy item to say there was none
        return temp;
    }
    public User UserFromID(int ID, int mode = 0, int IDToRemove = 0) // 0 is get user, 1 is get their ID
    {
        foreach (User u in _users)
        {
            if (u.GetID() == ID)
                if (mode == 0)
                    return u;
                else if (mode == 1) // get ID
                    u.RemoveOpenCheckoutID(IDToRemove);
        }
        //Console.WriteLine("There is no person with that ID!");
        User temp = new User(-1);
        return temp;
    }

    public int GetNewIDNumber()
    {
        Random random = new Random();
        int checkValue = random.Next(1, 100000); // between 1 and 99999

        while (true)
        {
            if ((ItemFromID(checkValue).GetID() == -1) && (UserFromID(checkValue).GetID() == -1)) // check to see if there is anything with an ID of checkValue
            {
                return checkValue; // if no item matched that ID, it's an available ID number
            }
            else
            {
                checkValue = random.Next();
                //else, keep going up until we find one
            }
        }
    }
    public bool LoadFromFile(string filepath = "autosave.txt")
    {

        if (File.Exists(filepath))
        {
            List<Item> loadedItems = new List<Item>();
            List<User> loadedUsers = new List<User>();

            string[] loadStrings = System.IO.File.ReadAllLines(filepath);
            foreach (string s in loadStrings)
            {
                string[] parts = s.Split("||");
                if (parts[0] == "Item")
                {
                    loadedItems.Add(new Item(parts[1], parts[2], parts[3], parts[4], parts[5]));
                    // id, name, out, dueback
                }
                else if (parts[0] == "ItemTripod")
                {
                    loadedItems.Add(new ItemTripod(parts[1], parts[2], parts[3], parts[4], parts[5], parts[6]));
                }
                else if (parts[0] == "ItemProjector")
                {
                    loadedItems.Add(new ItemProjector(parts[1], parts[2], parts[3], parts[4], parts[5], parts[6]));
                }
                else if (parts[0] == "ItemCamera")
                {
                    loadedItems.Add(new ItemCamera(parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7]));

                }
                else if (parts[0] == "User")
                {
                    List<int> checkoutIDs = new List<int>();
                    int numIDs = int.Parse(parts[4]);
                    if (numIDs > 0)
                    {
                        for (int i = 1; i <= numIDs; i++)
                        {
                            checkoutIDs.Add(int.Parse(parts[4 + i]));
                        }
                    }
                    loadedUsers.Add(new User(parts[1], parts[2], parts[3], checkoutIDs));
                }
                else
                {
                    //you did something wrong to get here
                }
            }
            _items.Clear();
            _users.Clear();
            _items = loadedItems;
            _users = loadedUsers;
            return true;
        }
        else
        {
            Console.WriteLine($"Sorry, {filepath} does not exist.");
            return false;
        }
    }
    public void SaveToFile(string filepath = "autosave.txt")
    {
        using (StreamWriter outputFile = new StreamWriter(filepath))
        {
            foreach (Item i in _items)
            {
                outputFile.WriteLine(i.GetSavableData());
            }
            foreach (User u in _users)
            {
                outputFile.WriteLine(u.GetSavableData());
            }
        }
    }
    public List<Item> GetFilteredItems(string filtertype, string filtercategory = "all")
    {
        List<Item> returnList = new List<Item>();

        switch (filtercategory)
        {
            case "all":
                foreach (Item i in _items)
                {
                    returnList.Add(i);
                }
                break;
            case "camera":
                foreach (Item i in _items)
                {
                    if (i is ItemCamera)
                        returnList.Add(i);
                }
                break;
            case "tripod":
                foreach (Item i in _items)
                {
                    if (i is ItemTripod)
                        returnList.Add(i);
                }
                break;
            case "projector":
                foreach (Item i in _items)
                {
                    if (i is ItemProjector)
                        returnList.Add(i);
                }
                break;
        }



        switch (filtertype)
        {
            case "all":
                //do nothing, we already have all
                break;
            case "available":
                foreach (Item i in _items)
                {
                    if (i.IsCheckedOut())
                    {
                        returnList.Remove(i);
                    }
                }
                break;
            case "checked out":
                foreach (Item i in _items)
                {
                    if (!i.IsCheckedOut())
                    {
                        returnList.Remove(i);
                    }
                    returnList.Sort((x, y) => DateTime.Compare(x.GetDueBackTime(), y.GetDueBackTime())); // return sorted by date
                }
                break;
            case "by user":
                returnList = GetFilteredItems("checked out");
                break;
        }
        return returnList;
    }


    public void CheckItem(bool checkingOut, string filtercategory = "all") // true is checking out 
    {
        List<Item> pickItemList; // get a list of items
        if (checkingOut)
            pickItemList = GetFilteredItems("available", filtercategory);
        else
            pickItemList = GetFilteredItems("checked out");

        List<string> pickItemListString = new List<string>();
        foreach (Item i in pickItemList)
        {
            pickItemListString.Add(i.GetPrintableData()); // get the printable data for each of those items
        }
        pickItemListString.Add("Cancel"); // add a cancel button
        int itemChoiceNum = int.Parse(MenuChoiceHandler(pickItemListString, returnAsNumber: true)); // have the user pick what to check in/out

        if (itemChoiceNum != pickItemListString.Count()) // make sure cancel isn't picked
        {
            if (checkingOut)
            {
                Console.WriteLine("Who are we checking it out to?");
                List<string> pickUserListString = new List<string>();
                foreach (User u in _users)
                {
                    pickUserListString.Add(u.GetPrintableData());
                }
                pickUserListString.Add("Check out to a new user");
                pickUserListString.Add("Cancel");

                int userChoiceNum = int.Parse(MenuChoiceHandler(pickUserListString, returnAsNumber: true));

                    
                if (userChoiceNum != pickUserListString.Count()) //make sure cancel isn't picked again
                {
                    int checkeeID;
                    if (userChoiceNum == (pickUserListString.Count() - 1)) // if setting up a new user to check out to
                    {
                        User newUser = new User();
                        newUser.SetID(GetNewIDNumber());
                        Console.WriteLine($"Their new ID number is {newUser.GetID()}");
                        newUser.AddOpenCheckoutID(pickItemList[itemChoiceNum - 1].GetID()); // add id to item in quesiton to their list
                        AddUser(newUser);
                        checkeeID = newUser.GetID();
                        ItemFromID(pickItemList[itemChoiceNum - 1].GetID(), 1, checkeeID); // trigger a checkout on the actual item, not the cloned list. ID of item is added to user earlier
                    }
                    else // just checking out to a known user
                    {
                        _users[userChoiceNum - 1].AddOpenCheckoutID(pickItemList[itemChoiceNum - 1].GetID()); // get ID of the item we picked and add it to the user
                        checkeeID = _users[userChoiceNum - 1].GetID();
                        ItemFromID(pickItemList[itemChoiceNum - 1].GetID(), 1, checkeeID); // trigger a checkout on the actual item, not the cloned list. ID of item is added to user earlier
                    }

                }

            }
            else // checking in
            {
                ItemFromID(pickItemList[itemChoiceNum - 1].GetID(), 2);
                UserFromID(pickItemList[itemChoiceNum - 1].GetCheckeeID(), 1, pickItemList[itemChoiceNum - 1].GetID()); // option 1 removes this ID from the user in question
                // the above funciton says the item we picked, get the ID of they who checked it, find that user, remove said Item's ID from that user's list
            }

        }
    }
    public string MenuChoiceHandler(List<string> menuItems, string choicePrompt = "Choose an option: ", bool returnAsNumber = false) // take in a list of strings
    {
        // this function makes showing menus a lot easier. It takes in a list of strings, shows those as menu options, and returns the number you picked.
        Console.Clear();
        while (true)
        {
            int menuNum = 1;
            foreach (string item in menuItems)
            {
                Console.WriteLine($"{menuNum}. {item}");
                menuNum++;
            }
            Console.Write(choicePrompt);
            string userInput = Console.ReadLine();
            int menuChoice;
            if (int.TryParse(userInput, out menuChoice)) // try to parse the user input into an integer
            {
                if (menuChoice >= 1 && menuChoice <= menuItems.Count()) // if choice is in range
                {
                    if (returnAsNumber)
                        return menuChoice.ToString(); // not zero indexed
                    else
                        return menuItems[menuChoice - 1];
                }
            }
            // if parse and/or range unsuccessful, prompt user to do it right and try again
            Console.Clear();
            Console.WriteLine($"--- Please enter a number between 1 and {menuItems.Count()} ---");
        }

    }

}