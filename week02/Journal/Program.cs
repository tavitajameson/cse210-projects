using System;

class Program
{
    static void Main(string[] args)
    {
        // ================================================================
        // EXTRA CREDIT FEATURE (Creativity): Added Mood tags for each entry.
        // When writing a new entry, the user is also prompted for their mood
        // (e.g., Happy, Sad, Excited). This is saved, loaded, and displayed
        // along with the prompt, response, and date.
        // ================================================================

        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    Console.Write("Your mood (Happy, Sad, Excited, Stressed, Grateful): ");
                    string mood = Console.ReadLine();
                    journal.AddEntry(new Entry(prompt, response, mood));
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    Console.Write("Enter filename: ");
                    journal.SaveToFile(Console.ReadLine());
                    break;
                case "4":
                    Console.Write("Enter filename: ");
                    journal.LoadFromFile(Console.ReadLine());
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }
}