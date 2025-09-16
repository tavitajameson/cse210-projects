using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry) => _entries.Add(entry);

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.\n");
            return;
        }
        foreach (Entry e in _entries) e.Display();
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry e in _entries)
            {
                // Save with mood as well
                outputFile.WriteLine($"{e.Date}|{e.Prompt}|{e.Response}|{e.Mood}");
            }
        }
        Console.WriteLine("Journal saved successfully!\n");
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 4)
            {
                Entry e = new Entry(parts[1], parts[2], parts[3]) { Date = parts[0] };
                _entries.Add(e);
            }
        }
        Console.WriteLine("Journal loaded successfully!\n");
    }
}