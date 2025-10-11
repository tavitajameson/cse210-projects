using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _totalPoints;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _totalPoints = 0;
    }

    public int TotalPoints { get => _totalPoints; }

    public void AddGoal(Goal g) => _goals.Add(g);

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Create one!");
            return;
        }

        Console.WriteLine("\nGoals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEventForGoal(int index)
    {
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            return;
        }

        Goal g = _goals[index];
        int awarded = g.RecordEvent();
        if (awarded > 0)
        {
            _totalPoints += awarded;
            Console.WriteLine($"Total points: {_totalPoints}");
        }
    }

    public void SaveToFile(string path)
    {
        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine($"TotalPoints|{_totalPoints}");
            foreach (var g in _goals)
            {
                sw.WriteLine(g.GetSavedString());
            }
        }
        Console.WriteLine($"Saved {_goals.Count} goals and {_totalPoints} points to '{path}'.");
    }

    public void LoadFromFile(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("Save file not found.");
            return;
        }

        var lines = File.ReadAllLines(path);
        _goals.Clear();
        _totalPoints = 0;

        foreach (var raw in lines)
        {
            if (string.IsNullOrWhiteSpace(raw)) continue;

            var parts = SplitLine(raw);

            if (parts.Count == 0) continue;

            string type = parts[0];

            if (type == "TotalPoints" && parts.Count >= 2)
            {
                if (int.TryParse(parts[1], out int tp)) _totalPoints = tp;
            }
            else if (type == "Simple" && parts.Count >= 5)
            {
                string name = Unescape(parts[1]);
                string desc = Unescape(parts[2]);
                int pts = int.Parse(parts[3]);
                bool isComplete = bool.Parse(parts[4]);
                var sg = new SimpleGoal(name, desc, pts);
                if (isComplete)
                {
                    int awarded = sg.RecordEvent();
                    _totalPoints -= awarded;
                }
                _goals.Add(sg);
            }
            else if (type == "Eternal" && parts.Count >= 4)
            {
                string name = Unescape(parts[1]);
                string desc = Unescape(parts[2]);
                int pts = int.Parse(parts[3]);
                _goals.Add(new EternalGoal(name, desc, pts));
            }
            else if (type == "Checklist" && parts.Count >= 7)
            {
                string name = Unescape(parts[1]);
                string desc = Unescape(parts[2]);
                int pts = int.Parse(parts[3]);
                int current = int.Parse(parts[4]);
                int target = int.Parse(parts[5]);
                int bonus = int.Parse(parts[6]);

                var cg = new ChecklistGoal(name, desc, pts, target, bonus);
                for (int i = 0; i < current; i++)
                {
                    int awarded = cg.RecordEvent();
                    _totalPoints -= awarded; 
                }
                _goals.Add(cg);
            }
        }

        Console.WriteLine($"Loaded {_goals.Count} goals and {_totalPoints} points from '{path}'.");
    }

    public int ComputeLevel()
    {
        return (_totalPoints / 1000) + 1;
    }

    public List<string> GetBadges()
    {
        var badges = new List<string>();
        if (_totalPoints >= 100) badges.Add("Bronze Achiever");
        if (_totalPoints >= 500) badges.Add("Silver Striver");
        if (_totalPoints >= 1000) badges.Add("Gold Grinder");
        if (_totalPoints >= 5000) badges.Add("Platinum Pursuer");
        return badges;
    }

    private static List<string> SplitLine(string line)
    {
        var parts = new List<string>(line.Split('|'));
        return parts;
    }

    private static string Unescape(string s) => s.Replace("/|", "|");
}
