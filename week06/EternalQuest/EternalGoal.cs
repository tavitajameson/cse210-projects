using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        Console.WriteLine($"Eternal goal '{Name}' recorded! +{Points} points.");
        return Points;
    }

    public override string GetSavedString()
    {
        return $"Eternal|{Escape(Name)}|{Escape(Description)}|{Points}";
    }

    public override string GetDetailsString()
    {
        return $"[ ] {Name} ({Description}) -- {Points} pts (Eternal)";
    }

    private string Escape(string s) => s.Replace("|", "/|");
}
