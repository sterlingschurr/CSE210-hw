class Item
{
    protected int _itemID;
    protected string _itemName;
    protected bool _isCheckedOut;
    protected DateTime _dueBackTime;
    protected int _checkeeID = 0;

    public Item(string ID, string name, string checkedOut, string checkeeID, string duebacktime) // for loading items from a file
    {
        _itemID = int.Parse(ID);
        _itemName = name;
        _checkeeID = int.Parse(checkeeID);
        _isCheckedOut = bool.Parse(checkedOut);
        if (_isCheckedOut) _dueBackTime = DateTime.Parse(duebacktime);
        else _dueBackTime = DateTime.Now;
    }
    public Item(int ID) // for returning nulls
    {
        _itemID = ID;
    }
    public Item() // for creating items in program
    {
        Console.WriteLine("What is this item's name?");
        _itemName = Console.ReadLine();
    }
    public int GetCheckeeID() { return _checkeeID; }
    public void SetCheckeeID(int ID) { _checkeeID = ID; }

    public DateTime GetDueBackTime() { return _dueBackTime; }
    public virtual string GetPrintableData()
    {
        string returnString = $"{_itemID.ToString().PadLeft(5, '0')}|{_itemName.PadRight(20)} | ";
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
    public virtual string GetSavableData()
    {
        string returnString = $"Item||{_itemID.ToString()}||{_itemName}||{_isCheckedOut}||{_checkeeID}||";
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
    public virtual void CheckOut()
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
    public void CheckIn()
    {
        if (_dueBackTime < DateTime.Now) // if the item was due back before now, aka late
        {
            Console.WriteLine("!!! This Item is late! !!!");
            Console.WriteLine("Press Enter to acknowledge...");
            Console.ReadLine();
        }
        _isCheckedOut = false;
        Console.Write("Thanks! Item is checked in.");
        for (int i = 0; i < 5; i++)
        {
            Console.Write("."); // wait a lil bit to show message before going back
            Thread.Sleep(750);
        }

    }
    public bool IsCheckedOut() { return _isCheckedOut; }
    public void SetID(int ID) { _itemID = ID; }
    public int GetID() { return _itemID; }

}