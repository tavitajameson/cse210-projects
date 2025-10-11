using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            Console.WriteLine("This goal is already complete. No points awarded.");
            return 0;
        }

        _isComplete = true;
        Console.WriteLine($"Simple goal '{Name}' completed! +{Points} points.");
        return Points;
    }

    public override string GetSavedString()
    {
        return $"Simple|{Escape(Name)}|{Escape(Description)}|{Points}|{_isComplete}";
    }

    public override string GetDetailsString()
    {
        string mark = _isComplete ? "[X]" : "[ ]";
        return $"{mark} {Name} ({Description}) -- {Points} pts";
    }

    private string Escape(string s) => s.Replace("|", "/|");
}
