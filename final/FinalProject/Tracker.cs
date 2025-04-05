public class Tracker
{
    private double _goalProtein;
    private double _totalProtein;

    // Constructor.
    public Tracker(double goalProtein)
    {
        _goalProtein = goalProtein;
        _totalProtein = 0;
    }

    // Adding the protein intake to the total.
    public void IntakeUpdate(double protein)
    {
        _totalProtein += protein;
    }

    // Comparing if the total protein is reaching the goal.
    public string GetProgress()
    {
        return $"Total Protein: {_totalProtein}/{_goalProtein} grams.";
    }

    // Resetting the protein total for the protein goal.
    public string ResetProtein()
    {
        _totalProtein = 0;
        return $"Total Protein: {_totalProtein}/{_goalProtein} grams.";
    }
}