public class Running : Activity
{
    private double _distance; // in km

    public Running(string date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed() => (_distance / GetMinutes()) * 60;

    public override double GetPace() => GetMinutes() / _distance;

    public override double GetCaloriesBurned()
    {
        double met = 9.8;
        return met * GetWeight() * (GetMinutes() / 60.0);
    }
}