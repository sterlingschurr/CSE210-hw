using System;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        DateTime currentDateTime = DateTime.Now;
        newEntry._date = currentDateTime.ToShortDateString();
        _entries.Add(newEntry);
        Console.WriteLine("\nNew entry recorded!\n");
    }
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nThere aren't any entries yet...\n");
        }
        else
        {
            Console.WriteLine($"\nHere is everything we have in the journal. There are {_entries.Count} entries.\n");
            foreach (Entry e in _entries)
            {
                e.Display();
                Console.WriteLine();
            }
        }
    }
    public void SaveToFile(string filePath)
    {
        using (StreamWriter file = new StreamWriter(filePath))
        {
            Console.WriteLine($"Writing journal data to {filePath}...");
            foreach (Entry e in _entries)
            {
                file.WriteLine($"{e._date}~~{e._promptText}~~{e._entryText}");
            }
            Console.WriteLine("Done!\n");
        }
    }
    public void LoadFromFile(string filePath)
    {
        _entries.Clear();
        Console.WriteLine("Cleared old journal...");
        Console.WriteLine($"Reading in new journal from {filePath}...");
        string[] entries = System.IO.File.ReadAllLines(filePath);
        foreach (string entry in entries)
        {
            string[] parts = entry.Split("~~"); // 0 is date, 1 is prompt, 2 is entry
            Entry tempEntry = new Entry();
            tempEntry._date = parts[0];
            tempEntry._promptText = parts[1];
            tempEntry._entryText = parts[2];
            _entries.Add(tempEntry);
        }
        Console.WriteLine("Done!\n");

    }
}