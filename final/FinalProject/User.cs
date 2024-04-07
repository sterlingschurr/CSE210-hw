class User
{
    private string _firstName;
    private string _lastName;
    private int _userID;
    private List<int> _openCheckoutIDs = new List<int>(); // all the IDs of things the user has currently checked out

    public User(string first, string last, string ID, List<int> checkoutIDs) // for loading from files
    {
        _firstName = first;
        _lastName = last;
        _userID = int.Parse(ID);
        _openCheckoutIDs = checkoutIDs;
    }
    public User(int ID) // for returning nulls
    {
        _userID = ID;
    }
    public User()
    {
        Console.WriteLine("What is this User's first name?");
        _firstName = Console.ReadLine();
        Console.WriteLine("And the User's last name?");
        _lastName = Console.ReadLine();
        Console.WriteLine($"{_firstName} {_lastName} created as new user");
    }
    public string GetFirstName() { return _firstName; }
    public void SetFirstName(string name) { _firstName = name; }
    public string GetLastName() { return _lastName; }
    public void SetLastName(string name) { _lastName = name; }
    public int GetID() { return _userID; }
    public void SetID(int number) { _userID = number; }
    public List<int> GetOpenCheckoutIDs() { return _openCheckoutIDs; }
    public void AddOpenCheckoutID(int ID) { _openCheckoutIDs.Add(ID); }
    public void RemoveOpenCheckoutID(int ID) { _openCheckoutIDs.Remove(ID); }

    public string GetPrintableData()
    {
        return $"{_userID.ToString().PadLeft(5, '0')}|{(_firstName + " " + _lastName).PadRight(20)} | ";
    }
    public string GetSavableData()
    {
        string returnString = $"User||{_firstName}||{_lastName}||{_userID}||{_openCheckoutIDs.Count()}";
        foreach (int o in _openCheckoutIDs)
        {
            returnString += "||";
            returnString += o.ToString();
        }
        return returnString;
    }



}