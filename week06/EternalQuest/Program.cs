using System;

/*
 Creative Points
  Added a simple Leveling and Badge system:
   -Level increases every 1000 total points (Level 1 = 0-999).
   -Badges are awarded at thresholds: 100, 500, 1000, 5000 points.
 - These game-like features are described here and shown to the user when they view their score.
 - The save file stores the total points and enough data to reconstruct goals.
*/

public class Program
{
    static void Main()
    {
        var manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nEternal Quest - Main Menu");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event (complete a goal)");
            Console.WriteLine("4. Show Score & Level");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option (1-7): ");

            string input = Console.ReadLine()?.Trim();
            Console.WriteLine();

            switch (input)
            {
                case "1": CreateGoalFlow(manager); break;
                case "2": manager.ListGoals(); break;
                case "3": RecordEventFlow(manager); break;
                case "4": ShowScore(manager); break;
                case "5": SaveFlow(manager); break;
                case "6": LoadFlow(manager); break;
                case "7":
                    running = false;
                    Console.WriteLine("Goodbye — may your quests be fruitful!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Enter a number 1-7.");
                    break;
            }
        }
    }

    static void CreateGoalFlow(GoalManager manager)
    {
        Console.WriteLine("Create New Goal");
        Console.WriteLine("Types: 1) Simple  2) Eternal  3) Checklist");
        Console.Write("Choose type (1-3): ");
        string t = Console.ReadLine()?.Trim();

        Console.Write("Name: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Description: ");
        string desc = Console.ReadLine() ?? "";
        Console.Write("Points (integer): ");
        if (!int.TryParse(Console.ReadLine(), out int pts)) pts = 0;

        if (t == "1")
        {
            manager.AddGoal(new SimpleGoal(name, desc, pts));
            Console.WriteLine("Simple goal created.");
        }
        else if (t == "2")
        {
            manager.AddGoal(new EternalGoal(name, desc, pts));
            Console.WriteLine("Eternal goal created.");
        }
        else if (t == "3")
        {
            Console.Write("Target count (how many times to finish): ");
            if (!int.TryParse(Console.ReadLine(), out int target)) target = 1;
            Console.Write("Bonus points upon completion: ");
            if (!int.TryParse(Console.ReadLine(), out int bonus)) bonus = 0;
            manager.AddGoal(new ChecklistGoal(name, desc, pts, target, bonus));
            Console.WriteLine("Checklist goal created.");
        }
        else
        {
            Console.WriteLine("Unknown type — aborting creation.");
        }
    }

    static void RecordEventFlow(GoalManager manager)
    {
        manager.ListGoals();
        Console.Write("Enter goal number to record: ");
        if (!int.TryParse(Console.ReadLine(), out int index))
        {
            Console.WriteLine("Invalid number.");
            return;
        }
        manager.RecordEventForGoal(index - 1);
    }

    static void ShowScore(GoalManager manager)
    {
        Console.WriteLine($"\nTotal Points: {manager.TotalPoints}");
        Console.WriteLine($"Level: {manager.ComputeLevel()}");
        var badges = manager.GetBadges();
        if (badges.Count == 0) Console.WriteLine("Badges: (none yet)");
        else
        {
            Console.WriteLine("Badges:");
            foreach (var b in badges) Console.WriteLine($" - {b}");
        }
    }

    static void SaveFlow(GoalManager manager)
    {
        Console.Write("Enter filename to save (e.g., save.txt): ");
        string path = Console.ReadLine() ?? "save.txt";
        manager.SaveToFile(path);
    }

    static void LoadFlow(GoalManager manager)
    {
        Console.Write("Enter filename to load (e.g., save.txt): ");
        string path = Console.ReadLine() ?? "save.txt";
        manager.LoadFromFile(path);
    }
}
