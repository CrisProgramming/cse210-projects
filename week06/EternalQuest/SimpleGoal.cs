public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
        _isComplete = false;
    }

    public SimpleGoal(string data) : base("", "", 0)
    {
        // Example: SimpleGoal:Exercise|Daily workout|20
        string[] parts = data.Split('|');
        _shortName = parts[0];
        _description = parts[1];
        _points = int.Parse(parts[2]);
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"Congratulations! You earned {_points} points for completing '{_shortName}'.");
        }
        else
        {
            Console.WriteLine($"'{_shortName}' is already completed.");
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStatus()
    {
        string checkmark = _isComplete ? "X" : " ";
        return $"[{checkmark}] {_shortName} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName}|{_description}|{_points}|{_isComplete}";
    }
}