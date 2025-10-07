using System;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;

        while (choice != 4)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                choice = 0;
            }

            Console.Clear();

            switch (choice)
            {
                case 1:
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    break;
                case 2:
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    break;
                case 3:
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    break;
                case 4:
                    Console.WriteLine("Goodbye! Remember to stay mindful. 🌿");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            if (choice != 4)
            {
                Console.WriteLine("\nPress Enter to return to the menu...");
                Console.ReadLine();
            }
        }
    }
}

/*
---------------------
EXCEEDING REQUIREMENTS
---------------------
 Added input validation for numeric entries.
 Added robust spinner and countdown animations with smooth timing.
 Enhanced reflection and listing logic to fully use allotted duration.
 Added consistent formatting, clear spacing, and unicode character for creative touch.
 Fully follows SOLID principles and naming conventions.
*/
