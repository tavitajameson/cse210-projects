using System;
//For creativity, I've added the option for a user to input how many words they would like to disappear.
//This will help them adjust the program to match their learning speed.

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Alma", 26, 12);
        string text = "Yea, I know that I am nothing; as to my strength I am weak; " +
                      "therefore I will not boast of myself, but I will boast of my God, " +
                      "for in his strength I can do all things; yea, behold, many mighty " +
                      "miracles we have wrought in this land, for which we will praise his name forever.";
        Scripture scripture = new Scripture(reference, text);

        int hideCount = 3;
        Console.Write("How many words would you like to hide per step? (default = 3): ");
        string inputHideCount = Console.ReadLine();
        if (int.TryParse(inputHideCount, out int chosen) && chosen > 0)
        {
            hideCount = chosen;
        }

        while (true)
        {
            Console.Clear();
            scripture.Display();

            if (scripture.AllHidden())
            {
                Console.WriteLine("\nAll words are hidden. Program will end.");
                break;
            }

            Console.WriteLine($"\nPress Enter to hide {hideCount} words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input?.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(hideCount);
        }
    }
}
