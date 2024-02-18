class Scripture
{
    private string[] _bodyText;
    private Reference _ref = new Reference();
    private List<Word> _words = new List<Word>();

    public void ParseLibEntry(string entry)
    {
        _words.Clear();
        string[] parts = entry.Split("~~"); // 0 is reference, 1 is verse
        _ref.SetRefText(parts[0]);
        _bodyText = parts[1].Split(" ");
        foreach (string t in _bodyText)
        {
            _words.Add(new Word(t));
        }
    }

    public void PrintScripture()
    {
        Console.WriteLine("\n"+_ref.GetRefText());
        foreach (Word w in _words)
        {
            Console.Write(w.GetWord()+" ");
        }
        Console.WriteLine("");
    }

    public void HideMoreWords(int blanksChance)// Enter between 0 and 100 chance of a word becoming a blank
    {
        Random random = new Random();
        foreach (Word w in _words)
        {
            if ((blanksChance > random.Next(0, 100)))
                w.SetWordHidden(true);
        }
    }

    public bool AreAllWordsHidden()
    {
        bool allAreHidden = true;
        foreach(Word w in _words)
        {
            if(!w.IsWordHidden())
            {
                allAreHidden = false;
            }
        }
        return allAreHidden;
    }
}