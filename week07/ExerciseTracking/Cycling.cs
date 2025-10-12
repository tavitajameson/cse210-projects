public class Cycling : Activity
{
    private double _speed; // kph

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => (GetSpeed() * GetMinutes()) / 60;
    public override double GetSpeed() => _speed;
    public override double GetPace() => 60 / GetSpeed();
}
