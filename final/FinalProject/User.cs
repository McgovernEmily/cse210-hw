public class User
{
    private string _name;
    private double _weight;
    private string _gender;
    private int _activityLevel;
    private double _proteinGoal;

    // Constructor.
    public User(string name, double weight, string gender, int activityLevel, double proteinGoal)
    {
        _name = name;
        _weight = weight;
        _gender = gender;
        _activityLevel = activityLevel;
        _proteinGoal = proteinGoal;
    }


    // Getting the name of the user.
    public string GetName()
    {
        return _name;
    }

    // Getting the weight of the user.
    public double GetWeight()
    {
        return _weight;
    }

    // Getting the protein Goal.
    public double GetProteinGoal()
    {
        return _proteinGoal;
    }

    // This will calculate a protein recommendation based on the user's weight and activity level.
    public string CalculateProtein()
    {
        return $"Still working on it";
    }

}