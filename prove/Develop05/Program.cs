using System;
using System.Collections.Generic;
using System.IO;

namespace GoalTrackingApp
{
    class Program
    {
        // Display a random motivational quote
        static void DisplayMotivationalQuote()
        {
            string[] quotes = {
                "Believe you can and you're halfway there.",
                "The only limit to our realization of tomorrow is our doubts of today.",
                "Act as if what you do makes a difference. It does.",
                "Success is not final, failure is not fatal: It is the courage to continue that counts."
            };
            Random rand = new Random();
            int index = rand.Next(quotes.Length);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\nDaily Motivation: {quotes[index]}");
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            // Create an instance of GoalManager
            DisplayMotivationalQuote();
            GoalManager goalManager = new GoalManager();
            bool running = true;

            while (running)
            {
                // Display menu options to the user
                Console.WriteLine("\nGoal Tracking Application");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Create a new goal");
                Console.WriteLine("2. List goals");
                Console.WriteLine("3. Save goals");
                Console.WriteLine("4. Load goals");
                Console.WriteLine("5. Record events");
                Console.WriteLine("6. Quit");
                Console.ResetColor();
                Console.Write("Choose an option: ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                // Handle user's menu choice
                switch (choice)
                {
                    case 1:
                        goalManager.CreateGoal();
                        break;
                    case 2:
                        goalManager.ListGoals();
                        break;
                    case 3:
                        goalManager.SaveGoals();
                        break;
                    case 4:
                        goalManager.LoadGoals();
                        break;
                    case 5:
                        goalManager.RecordEvent();
                        break;
                    case 6:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

}