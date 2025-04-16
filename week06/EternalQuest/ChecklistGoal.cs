public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus)
        : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(string data) : base("", "", 0)
    {
        // Example: ChecklistGoal:Attend church|Weekly service|25|3|100|1
        string[] parts = data.Split('|');
        _shortName = parts[0];
        _description = parts[1];
        _points = int.Parse(parts[2]);
        _target = int.Parse(parts[3]);
        _bonus = int.Parse(parts[4]);
        _amountCompleted = int.Parse(parts[5]);
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            Console.WriteLine($"Progress! {_shortName}: {_amountCompleted}/{_target}");
        }
        else
        {
            Console.WriteLine($"'{_shortName}' is already completed.");
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetStatus()
    {
        string checkmark = IsComplete() ? "X" : " ";
        return $"[{checkmark}] {_shortName} ({_description}) -- Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName}|{_description}|{_points}|{_target}|{_bonus}|{_amountCompleted}";
    }

    public int GetBonusPoints() => _bonus;
}