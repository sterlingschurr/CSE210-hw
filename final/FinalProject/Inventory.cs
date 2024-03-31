using System.Runtime.InteropServices;

class Inventory
{
    List<User> users;
    List<Item> items;

    private int FindItemArrayLocation(int ID)
    {
        int counter = 0;
        foreach (Item i in items)
        {

            if (i.GetID() == ID)
            {
                return counter;
            }
            else
            {
                counter++;
            }
        }
        return -1;
    }
    public Item GetItemFromID(int ID)
    {
        Item temp = new Item();
        int tempArray = FindItemArrayLocation(ID);
        if (tempArray == -1)
        {
            //item doesn't exist
            temp.SetID(-1);
            Console.WriteLine("There is no item with that ID!");
        }
        else
        {
            temp = items[tempArray];
        }
        return temp;
    }

    public int GetNextIDNumber()
    {
        int checkValue = 1;

        while (true)
        {
            if (FindItemArrayLocation(checkValue) == -1) // check to see if there is an item with ID of checkValue
            {
                return checkValue; // if no item matched that ID, it's the next available ID number
            }
            else
            {
                checkValue++;
                //else, keep going up until we find one
            }
        }
    }
    public void LoadUsersFromFile()
    {

    }
    public void SaveUsersToFile()
    {

    }
    public void LoadItemsFromFile()
    {

    }
    public void SaveItemsToFile()
    {

    }
    public void DisplayAvailableItems()
    {

    }
    
    public int MenuChoiceHandler(List<string> menuItems, string choicePrompt = "Choose an option: ") // take in a list of strings
    {
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
                    return menuChoice;
                }
            }
            // if parse and/or range unsuccessful, prompt user to do it right and try again
            Console.Clear();
            Console.WriteLine($"--- Please enter a number between 1 and {menuItems.Count()} ---");
        }

    }

}