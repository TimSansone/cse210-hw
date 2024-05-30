using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

class Word
{
    private string _text;
    private bool _isHidden;

    // Constructor initializes the word and sets it as not hidden
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Method to hide the word
    public void Hide()
    {
        _isHidden = true;
    }

    // Method to check if the word is hidden
    public bool IsWordHidden()
    {
        return _isHidden;
    }

    public string GetText() => _text;

    // Overrides the ToString method to display either the word or underscores if hidden
    public override string ToString()
    {
        return _isHidden ? $"{{{new string('_', _text.Length)}}}" : _text;
    }
}
