using System;
using System.Collections.Generic;
using System.IO;

// Main program 
class Program
{
    static void Main()
    {
        // Creates an instance of the Journal class
        Journal journal = new Journal();
        // Default filename for saving journal entries
        string filename = "journal.txt";

        // Display the journal menu and handle user input
        while (true)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Journal Menu:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Write a new journal entry");
            Console.WriteLine("2. Display your journal entries");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option (1-5): ");
            Console.ForegroundColor = ConsoleColor.White;

            // Validate and process the user's choice
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Adding a new entry...");
                        // Gets the current date and time to create a timestamp for entry
                        string date = DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
                        // Gets a random question to ask the user
                        string question = QuestionAsker.GetRandomQuestion();
                        Console.WriteLine($"Question: {question}");
                        Console.Write("Enter your response: ");
                        string response = Console.ReadLine();
                        // Adds the new journal entry
                        journal.AddEntry(date, question, response);
                        break;
                    case 2:
                        Console.Clear();
                        // Displays all current or loaded journal entries
                        journal.DisplayEntries();
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Enter the filename to save the journal: ");
                        filename = Console.ReadLine();
                        // Saves the journal entries to a file that the user chooses
                        journal.SaveToFile(filename);
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Enter the filename to load the journal: ");
                        filename = Console.ReadLine();
                        // Loads the journal entries from a file
                        journal.LoadFromFile(filename);
                        break;
                    case 5:
                        // Exits the program
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }


}
