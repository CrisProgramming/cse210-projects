public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
    }

    public EternalGoal(string data) : base("", "", 0)
    {
        // Example format: EternalGoal:Read scriptures|Daily scripture study|50
        string[] parts = data.Split('|');
        _shortName = parts[0];
        _description = parts[1];
        _points = int.Parse(parts[2]);
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Great! You earned {_points} points for completing '{_shortName}'.");
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStatus()
    {
        return $"[∞] {_shortName} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName}|{_description}|{_points}";
    }
}