using System;
using System.Collections.Generic;
using System.IO;

// Class representing a Journal Entry
class JournalEntry
{
    // Date of the journal entry
    public string Date; 

    // Question related to the journal entry
    public string Question; 

    // Response to the question, which will be the new journal entry
    public string Response; 

    // Constructor to initialize the JournalEntry with date, question, and response
    public JournalEntry(string _date, string _question, string _response)
    {
        // Set the Date property to the provided date value
        Date = _date;  
        // Set the Question property to the provided question value
        Question = _question; 
        // Set the Response property to the provided response value
        Response = _response; 
    }
}