public abstract class Meal
{
    protected string _name;
    protected double _protein;

    // Constructor
    public Meal(string name, double protein)
    {

        _name = name;
        _protein = protein;
    }

    // Get protein to share with other classes.
    public double GetProtein()
    {
        return _protein;
    }

    public void SetProtein(double protein)
    {
        _protein = protein;
    }

    // The abstract for entering a meals details.
    public abstract void EnterMealDetails();
}