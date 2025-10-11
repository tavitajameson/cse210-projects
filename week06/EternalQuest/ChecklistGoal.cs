using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int pointsPer, int targetCount, int bonusPoints)
        : base(name, description, pointsPer)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        if (_currentCount >= _targetCount)
        {
            Console.WriteLine("This checklist goal is already complete. No points awarded.");
            return 0;
        }

        _currentCount++;
        int awarded = Points;
        Console.WriteLine($"Checklist goal '{Name}' progress: {_currentCount}/{_targetCount} (+{Points} pts).");

        if (_currentCount >= _targetCount)
        {
            awarded += _bonusPoints;
            Console.WriteLine($"Congrats! Checklist goal completed. Bonus +{_bonusPoints} pts awarded.");
        }

        return awarded;
    }

    public override string GetSavedString()
    {
        return $"Checklist|{Escape(Name)}|{Escape(Description)}|{Points}|{_currentCount}|{_targetCount}|{_bonusPoints}";
    }

    public override string GetDetailsString()
    {
        string mark = _currentCount >= _targetCount ? "[X]" : "[ ]";
        return $"{mark} {Name} ({Description}) -- {Points} pts each (Completed {_currentCount}/{_targetCount})";
    }

    private string Escape(string s) => s.Replace("|", "/|");
}
