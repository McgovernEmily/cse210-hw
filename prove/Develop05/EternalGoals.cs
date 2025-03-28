public class EternalGoals : Goals
{
    private int _amountCompleted;

    public EternalGoals(string name, string description, int points) : base(name, description, points)
    {
        _amountCompleted = 0;
    }

    // Changing the record to put how many times that goal was completed.
    public override int Record()
    {
        _amountCompleted++;
        return GetPoints();
    }

    // Displays the status of this goal as how many times it was completed.
    public override string Status()
    {
        return $"[Completed {_amountCompleted} times]";
    }
}