using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

// Reference class to represent a scripture reference
class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    // Constructor for a single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    // Constructor for multiple verses
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // Method to get the book name
    public string GetBook() => _book;

    // Method to get the chapter number
    public int GetChapter() => _chapter;

    // Method to get the starting verse number
    public int GetStartVerse() => _startVerse;

    // Method to get the ending verse number
    public int GetEndVerse() => _endVerse;

    // Overrides the ToString method to display the reference correctly
    public override string ToString()
    {
        return _startVerse == _endVerse ? $"{_book} {_chapter}:{_startVerse}" : $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}