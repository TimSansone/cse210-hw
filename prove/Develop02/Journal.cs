using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

// Journal class for managing and interacting with journal entries
class Journal
{
    // Private list to store journal entries
    private List<JournalEntry> entries = new List<JournalEntry>();

    // Add a new journal entry to the list
    public void AddEntry(string date, string question, string response)
    {
        entries.Add(new JournalEntry(date, question, response ));
        Console.WriteLine("Your journal entry has been added.");
    }

    // Display all journal entries in the list
    // Method to display journal entries and show the total number of entries
public void DisplayEntries()
{
    Console.Clear();
    Console.WriteLine("Here are your journal entries:");
    
    int entryCount = 0;  // Variable to store the count of entries

    // Iterate through each entry in the entries list
    foreach (var entry in entries)
    {
        // Displays the entry number
        Console.WriteLine($"Entry # {entryCount + 1}:");
        Console.ForegroundColor = ConsoleColor.Red;
        // Displays the date and time that the entry was created
        Console.WriteLine($"Date: {entry.Date}");
        
        Console.ForegroundColor = ConsoleColor.Blue;
        // Displays the question that was asked to prompt the journal entry
        Console.WriteLine($"Question: {entry.Question}");
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        // Displays the response to the question that was asked
        Console.WriteLine($"Response: {entry.Response}");
        
        // Horizontal separator line
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("---------------------------------------------------");
        
        Console.ResetColor();  // Reset console colors
        
        entryCount++;  // Increment the entry count for each entry
    }

    // Display the total number of entries
    Console.WriteLine($"Total number of entries: {entryCount}");
}

    // Save journal entries to a file using StreamWriter
    // Method to save journal entries to a file
public void SaveToFile(string filename)
{
    // Open the specified file for writing
    using (StreamWriter writer = new StreamWriter(filename)) 
    {
        // Iterate through each journal entry
        foreach (var entry in entries) 
        {
            // Write the date of the entry to the file
            writer.WriteLine($"Date: {entry.Date}");  
            // Write the question of the entry to the file
            writer.WriteLine($"Question: {entry.Question}");  
            // Write the response of the entry to the file
            writer.WriteLine($"Response: {entry.Response}");  
            // Separator line
            writer.WriteLine("---------------------------------------------------");  
        }
    }
    // Display success message
    Console.WriteLine($"Your journal has been successfully saved in {filename}.");  
}

    // Load journal entries from a file
    // Method to load journal entries from a file
public void LoadFromFile(string filename)
{
    // Clear the existing entries list before loading new entries
    entries.Clear();  
    try
    {
        // Open the specified file for reading
        using (StreamReader reader = new StreamReader(filename))  
        {
            // Initialize a variable to store the current journal entry
            JournalEntry entry = null;  

            // Read the file line by line until the end of the file is reached
            while (!reader.EndOfStream)
            {
                // Read the next line from the file
                string line = reader.ReadLine();  

                // Check if the line represents the "Date" of a journal entry
                if (line.StartsWith("Date: "))
                {
                    // Extract the date value from the line
                    string date = line.Substring("Date: ".Length);
                    // Create a new JournalEntry object with the extracted date and empty question/response
                    entry = new JournalEntry(date, "", "");
                }
                // Check if the line represents the "Question" of a journal entry and an entry has been initiated
                else if (line.StartsWith("Question: ") && entry != null)
                {
                    // Extract the question value from the line and assign it to the current entry
                    entry.Question = line.Substring("Question: ".Length);
                }
                // Check if the line represents the "Response" of a journal entry and an entry has been initiated
                else if (line.StartsWith("Response: ") && entry != null)
                {
                    // Extract the response value from the line and assign it to the current entry
                    entry.Response = line.Substring("Response: ".Length);
                    // Add the completed entry to the entries list
                    entries.Add(entry);  
                }
            }
        }
        Console.WriteLine("Your journal has loaded successfully.");  
    }
    // Catch any exceptions that occur during the file loading process
    catch (Exception ex)  
    {
        // Display an error message with the exception details
        Console.WriteLine($"Error loading journal: {ex.Message}");  
    }
}
}