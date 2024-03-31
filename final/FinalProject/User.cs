class User
{
    private string _firstName;
    private string _lastName;
    private int _userID;

    private List<int> _openCheckoutIDs; // all the IDs of things the user has currently checked out

    public string GetFirstName() {return _firstName;}
    public void SetFirstName(string name) {_firstName = name;}
    public string GetLastName() {return _lastName;}
    public void SetLastName(string name) {_lastName = name;}
    public int GetUserID() {return _userID;}
    public void SetUserID(int number) {_userID = number;}

    public string GetPrintableData()
    {
        return "";
    }
    public string GetSavableData()
    {
        return "";
    }

    public List<int> GetOpenCheckoutIDs()
    {
        return _openCheckoutIDs;
    }
}