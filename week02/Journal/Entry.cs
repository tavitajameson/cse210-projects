using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Mood { get; set; }  // NEW feature

    public Entry(string prompt, string response, string mood)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd");
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"{Date} - Prompt: {Prompt}");
        Console.WriteLine($"Mood: {Mood}");
        Console.WriteLine($"Response: {Response}\n");
    }
}