public class CheckListGoals : Goals
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public CheckListGoals(string name, string description, int points, int targetCount, int currentCount, int bonusPoints) : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = currentCount;
        _bonusPoints = bonusPoints;
    }

    // Getting the bonusPoints.
    public int GetBonusPoints()
    {
        return _bonusPoints;
    }

    // Shows how the goal is complete.
    public override int Record()
    {
        // When completed it will add 1 to the current count.
        _currentCount++;

        // If the current count is larger or equal to target count then it gets bonus points.
        if (_currentCount >= _targetCount)
        {
            return GetPoints() + _bonusPoints;
        }

        return GetPoints();
    }

    // Displays the status as (0/3).
    public override string Status()
    {
        return $"[{_currentCount}/{_targetCount}]";
    }
}