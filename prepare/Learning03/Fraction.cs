public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {

    }
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }
    public Fraction(int topInput, int bottomInput)
    {
        _top = topInput;
        _bottom = bottomInput;
    }

    public int GetTop()
    {
        return _top;
    }
    public int GetBottom()
    {
        return _bottom;
    }
    public void SetTop(int top)
    {
        _top = top;
    }
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }


    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }
    public double GetDecimalValue()
    {
        // if (_bottom == 0)
        //     return 0;
        // else
        double top = _top;
        double bottom = _bottom;
        double retVal = top/bottom;
            return (retVal);
    }
}