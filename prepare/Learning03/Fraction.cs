using System;
class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Practicing with Get.
    public int GetTop()
    {
        return _top;
    }

    // Practicing with Set.
    public void SetTop(int top)
    {
        _top = top;
    }

    // Practicing with Get.
    public int GetBottom()
    {
        return _bottom;
    }

    // Practicing with Set.
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        string num = $"{_top}/{_bottom}";
        return num;
    }

    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }

}