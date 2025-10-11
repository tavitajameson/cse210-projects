using System;

public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public string Name { get => _name; }
    public string Description { get => _description; }
    public int Points { get => _points; }

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();

    public abstract string GetSavedString();

    public virtual string GetDetailsString()
    {
        return $"[ ] {Name} ({Description}) -- {Points} pts";
    }
}
