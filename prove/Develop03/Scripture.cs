
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

// Scripture class to represent a scripture with a reference and words
class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // Constructor initializes the scripture reference and splits the text into words
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    // Method to hide random words in the scripture
    public int HideRandomWords()
    {
        Random random = new Random();
        // Randomly choose 3, 4,, or 5 words to hide
        int wordsToHideCount = random.Next(3, 6);
        var wordsToHide = _words.Where(w => !w.IsWordHidden()).OrderBy(w => random.Next()).Take(wordsToHideCount).ToList();

        foreach (var word in wordsToHide)
        {
            // Hide each word in the selected list of words to hide
            word.Hide();
        }

        return wordsToHide.Count;
    }

    // Method to check if all words are hidden
    public bool AreAllWordsHidden()
    {
        return _words.All(w => w.IsWordHidden());
    }

    // Method to print the scripture with hidden words in red
    public void Print()
    {
        Console.WriteLine(_reference.ToString());
        foreach (var word in _words)
        {
            if (word.IsWordHidden())
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(word + " ");
                Console.ResetColor();
            }
            else
            {
                Console.Write(word + " ");
            }
        }
        Console.WriteLine();
    }

    // Method to get the total number of words in the scripture
    public int TotalWords()
    {
        return _words.Count;
    }

public Reference GetReference() => _reference;
public List<Word> GetWords() => _words;

    // Overrides the ToString method to display the reference
    public override string ToString()
    {
        return _reference.ToString();
    }
}