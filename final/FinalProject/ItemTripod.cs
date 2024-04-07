class ItemTripod : Item
{
    private int _heightInCM;
    public ItemTripod(string ID, string name, string checkedOut, string checkeeID, string height, string duebacktime) : base(ID, name, checkedOut, checkeeID, duebacktime) // for loading items from a file
    {
        _heightInCM = int.Parse(height);
    }
    public ItemTripod(int ID) : base(ID) // for returning nulls
    {

    }
    public ItemTripod() // for creating items in program
    {
        Console.WriteLine("What is the tripod's height in CM?");
        _heightInCM = int.Parse(Console.ReadLine());
    }

public override string GetPrintableData()
    {
        string returnString = $"{_itemID.ToString().PadLeft(5, '0')}|{_itemName.PadRight(20)} | Tripod | {_heightInCM} CM tall |";
        if (_isCheckedOut)
        {
            returnString += $"OUT | Due Back: {_dueBackTime.ToString("MM-dd")}";
            if (_dueBackTime < DateTime.Now)
            {
                returnString += "| !!! LATE !!!";
            }
            returnString += $"Checked out to ID {_checkeeID.ToString().PadLeft(5, '0')}";
        }
        else
        {
            returnString += "IN  |";
        }

        return returnString;
    }
    public override string GetSavableData()
    {
        string returnString = $"ItemTripod||{_itemID.ToString()}||{_itemName}||{_isCheckedOut}||{_checkeeID}||{_heightInCM}||";
        if (_isCheckedOut)
        {
            returnString += _dueBackTime.ToString("yyyy-MM-dd");
        }
        else
        {
            returnString += "1970-01-01";
        }
        return returnString;
    }
    public override void CheckOut()
    {
        Console.WriteLine("How many days to check it out for?");
        string daysToCheckOut = Console.ReadLine();
        int numDays;

        if (int.TryParse(daysToCheckOut, out numDays)) // try to parse the user input into an integer
        {
            _dueBackTime = DateTime.Now.AddDays(numDays);
            _isCheckedOut = true;
            Console.Write("Item checked out successfully");
        }
        else
        {
            Console.Write("Invalid input! Item not checked out");
        }
        for (int i = 0; i < 5; i++)
        {
            Console.Write("."); // wait a lil bit to show message before going back
            Thread.Sleep(750);
        }


    }


}