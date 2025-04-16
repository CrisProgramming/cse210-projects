public abstract class Activity
{
    private string _date;
    private int _lengthInMinutes;
    private double _weightInKg = 70.0; // default weight

    public Activity(string date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public string GetDate() => _date;
    public int GetMinutes() => _lengthInMinutes;
    public double GetWeight() => _weightInKg;

    public void SetWeight(double weight) => _weightInKg = weight;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public abstract double GetCaloriesBurned();

    public virtual string GetSummary()
    {
        return $"{_date} {this.GetType().Name} ({_lengthInMinutes} min): Distance {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min/km, Calories: {GetCaloriesBurned():0} kcal";
    }
}