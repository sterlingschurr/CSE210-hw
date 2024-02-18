//using System.Dynamic;

class Library
{
    private List<string> _scripts = new List<string>();
    public Library()
    {
        string[] scripts = System.IO.File.ReadAllLines("ScriptureList.txt");//read scriptures from file
        foreach (string s in scripts)
        {
            _scripts.Add(s);
        }
        if (_scripts.Any())
        {
            Console.WriteLine($"({GetLibrarySize()}) Scriptures loaded from file...\n");
        }
    }

    public string GetRandomEntry()
    {
        Random random = new Random();
        int randomNumber = random.Next(0, _scripts.Count());
        return _scripts[randomNumber];
    }
    public int GetLibrarySize()
    {
        return _scripts.Count();
    }
}