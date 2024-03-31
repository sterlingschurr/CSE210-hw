class Item
{
    private string _itemName;
    private int _itemID;
    private int _defaultCheckoutLength;
    private bool _isCheckedOut;
    // time checked out
    // time due back

    public Item(bool setup = false)
    {
        if (setup)
        {
            Console.WriteLine("What is this item's name?");
            _itemName = Console.ReadLine();
            Console.WriteLine("What is the default checkout length (in days):");
            _defaultCheckoutLength = int.Parse(Console.ReadLine());
            
        }
    }

    public string GetPrintableData()
    {
        return "";
    }
    public string GetSavableData()
    {
        return "";
    }

    public bool IsCheckedOut()
    {
        // if available and not checked out;
        return _isCheckedOut;
    }
    public void SetID(int ID) { _itemID = ID; }
    public int GetID() { return _itemID; }

}