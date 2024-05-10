using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    // Represents an individual journal entry
    class Entry
    {
        public DateTime Date { get; set; } // Date of the entry
        public string Prompt { get; set; } // The prompt/question
        public string Response { get; set; } // User's response
    }

    // Manages a list of entries
    class Journal
    {
        private List<Entry> entries = new List<Entry>(); // List to store entries

        // Adds a new entry to the journal
        public void AddEntry(string prompt, string response)
        {
            var entry = new Entry
            {
                Date = DateTime.Now, // Set the current date and time
                Prompt = prompt, // Set the provided prompt
                Response = response // Set the user's response
            };
            entries.Add(entry); // Add the entry to the list
        }

        // Displays all entries in the journal
        public void DisplayEntries()
        {
            foreach (var entry in entries)
            {
                Console.WriteLine($"Date: {entry.Date}, Prompt: {entry.Prompt}, Response: {entry.Response}");
            }
        }

        // Saves the journal entries to a file (not implemented here)
        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"Date: {entry.Date}, Prompt: {entry.Prompt}, Response: {entry.Response}");
                }
            }
            Console.WriteLine($"Jornal saved to {filename}");   
        }

        // Loads journal entries from a file (not implemented here)
        public void LoadFromFile(string filename)
        {
            // Implement loading entries from a file (e.g., using StreamReader)
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var journal = new Journal(); // Create a new journal instance

            // Example prompts (add more as needed)
            var prompts = new List<string>
            {
                "1. Who was the most interesting person I interacted with today?",
                "2. What was the best part of my day?",
                "3. How did I see the hand of the Lord in my life today?",
                "4. What was the strongest emotion I felt today?",
                "5. If I had one thing I could do over today, what would it be?"
            };

            while (true)
            {
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Exit");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Choose a prompt:");
                        foreach (var prompt in prompts)
                        {
                            Console.WriteLine($"- {prompt}");
                        }
                        var selectedPrompt = Console.ReadLine();
                        Console.WriteLine("Enter your response:");
                        var response = Console.ReadLine();
                        journal.AddEntry(selectedPrompt, response);
                        break;
                    case "2":
                        journal.DisplayEntries();
                        break;
                    case "3":
                        Console.WriteLine("Enter a filename to save the journal:");
                        var saveFilename = Console.ReadLine();
                        journal.SaveToFile(saveFilename);
                        break;
                    case "4":
                        Console.WriteLine("Enter a filename to load the journal:");
                        var loadFilename = Console.ReadLine();
                        journal.LoadFromFile(loadFilename);
                        break;
                    case "5":
                        return; // Exit the program
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}