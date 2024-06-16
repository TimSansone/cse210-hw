using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

class Program
{
    static void Main()
    {
        // Menu logic to allow the user to choose activities and duration goes here
        Activity selectedActivity = null;
        DateTime start = DateTime.Now;

        // Main loop for the menu
        while (true)
        {
            // Display the menu options to the user
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            // Read user input for menu selection
            string input = Console.ReadLine();

            // Determine which activity to start based on user input
            if (input == "1")
            {

                selectedActivity = new BreathingActivity();
            }
            else if (input == "2")
            {
                selectedActivity = new ReflectionActivity();
            }
            else if (input == "3")
            {
                selectedActivity = new ListingActivity();
            }
            else if (input == "4")
            {
                Console.WriteLine("Exiting the program...");
                // Exut tge loop and end the program
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select a valid option.");
                // Prompt user again for valid input
                continue;
            }

            // Perform the selected activity
            if (selectedActivity != null)
            {
                // Start the activity
                selectedActivity.StartActivity();
                // End the activity
                selectedActivity.EndActivity();
            }
        }

    }
}