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

    // Calculate a protein recommendation based on the user's weight and activity level.
    public static double CalculateProtein(double weight, int activity)
    {
        double proteinRecommend = activity switch
        {
            1 or 2 => 0.8,
            3 or 4 => 1.2,
            5 => 1.8,
            _ => 1.0
        };

        return weight * proteinRecommend;
    }

}