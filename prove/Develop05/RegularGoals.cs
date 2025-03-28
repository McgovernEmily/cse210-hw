public class RegularGoals : Goals
{
    private bool _completed;

    public RegularGoals(string name, string description, int points) : base(name, description, points)
    {
        _completed = false;
    }

    // Records the completion for the Regular goal.
    public override int Record()
    {

        // The completion is either true or false (complete or not).
        if (!_completed)
        {
            _completed = true;
            return GetPoints();
        }

        return 0;
    }

    // Completion will mark it with an X if complete and nothing if not.
    public override string Status()
    {
        return _completed ? "[X]" : "[ ]";
    }

}