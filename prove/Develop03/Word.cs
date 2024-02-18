class Word
{
    private string _word;

    private bool _isHidden;
    public Word(string word)
    {
        _word = word;
    }
    public string GetWord()
    {
        if (_isHidden)
            return new string('_', _word.Count());
        else
            return _word;
    }
    public void SetWordHidden(bool isHidden)
    {
        _isHidden = isHidden;
    }
    public bool IsWordHidden()
    {
        return _isHidden;
    }
}