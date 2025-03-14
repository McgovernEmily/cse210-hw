using System.Drawing;
using Microsoft.VisualBasic;

public abstract class Goals
{
    private string _name;
    private string _description;
    private int _points;

    public Goals(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    // Get the name for the goals.
    public string GetName()
    {
        return _name;
    }

    // Get points so the points can be changed.
    public int GetPoints()
    {
        return _points;
    }

    // Get the description for the goals.
    public string GetDescription()
    {
        return _description;
    }


    // Other classes can use these to change the record and status.
    public abstract int Record();

    public abstract string Status();

}