using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ')
                     .Select(word => new Word(word))
                     .ToList();
    }

    public void Display()
    {
        Console.WriteLine(_reference.ToString());
        Console.WriteLine();

        foreach (Word word in _words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
    }

    public void HideRandomWords(int count)
    {
        List<Word> available = _words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < count && available.Count > 0; i++)
        {
            int index = _random.Next(available.Count);
            available[index].Hide();
            available.RemoveAt(index);
        }
    }

    public bool AllHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}
