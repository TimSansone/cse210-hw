using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

class Program
{
    static void Main()
    {
        // List of scriptures to choose from
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
            new Scripture(new Reference("Philippians", 4, 13), "I can do all this through him who gives me strength."),
            new Scripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd, I lack nothing."),
            new Scripture(new Reference("1 Nephi", 3, 7), "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."),
            new Scripture(new Reference("3 Nephi", 1, 13), "Lift up your head and be of good cheer; for behold, the time is at hand, and on this night shall the sign be given, and on the morrow come I into the world, to show unto the world that I will fulfil all that which I have caused to be spoken by the mouth of my holy prophets.")
        };

        // Prompt user to choose a scripture to memorize
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Choose a scripture to memorize:");
        Console.ResetColor();

        // Display list of scriptures
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{i + 1}. {scriptures[i].ToString()}");
            Console.ResetColor();
        }

        int _choice;

        // Loop to get a valid scripture choice from the user
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter the number of your choice: ");
            Console.ResetColor();
            if (int.TryParse(Console.ReadLine(), out _choice) && _choice >= 1 && _choice <= scriptures.Count)
            {
                // Break loop if valid choice is made
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice, please try again.");
            }
        }

        // Get the selected scripture
        Scripture selectedScripture = scriptures[_choice - 1];
        bool firstDisplay = true;
        int totalHiddenWords = 0;
        int totalWords = selectedScripture.TotalWords();

        // Main loop to display and hide words in the scripture
        while (true)
        {
            Console.Clear();
            
            // Checks to see if this is the first time the scripture is being displayed
            if (firstDisplay)
            {
                selectedScripture.Print();
                firstDisplay = false;
            }
            else
            {
                int hiddenWordsCount = selectedScripture.HideRandomWords();
                totalHiddenWords = totalHiddenWords + hiddenWordsCount;
                selectedScripture.Print();
                Console.WriteLine(hiddenWordsCount > 1
                    ? $"\n{hiddenWordsCount} words were hidden this time."
                    : $"\n{hiddenWordsCount} word was hidden this time.");
                Console.WriteLine($"\n{totalHiddenWords} words have been hidden out of {totalWords}.");
                
                // Break if all words are hidden
                if (selectedScripture.AreAllWordsHidden())
                {
                    break;
                }

            }

            // Prompt user to hide more words or quit
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string userOption = Console.ReadLine().ToLower();

            if (userOption == "quit")
            {
                break;
            }

            if (string.IsNullOrWhiteSpace(userOption))
            {
                Countdown(3);
            }
        }

        Console.WriteLine("Program ended.");
    }

    // Countdown method to pause and display countdown clock
    // before displaying the next scripture
    static void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Clear();
            Console.Write("Hang on, while I hide some of the words in the scripture.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("The scripture with additional words hidden will be displayed in ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(i);
            Console.ResetColor();
            Console.WriteLine(" seconds.");
            Thread.Sleep(1000);
        }
    }
}