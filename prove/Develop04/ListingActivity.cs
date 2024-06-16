using System;
using System.Threading;

// Derived class for listing activity
class ListingActivity : Activity
{
    private string[] prompts = new string[]
    {
        "List as many fruits as you can",
        "List as many animals as you can",
        "List as many countries as you can",
        "List as many movies as you can"
    };

    public override void StartActivity()
    {
        // Calls the base class method
        base.StartActivity();

        Random rnd = new Random();
        int promptIndex = rnd.Next(prompts.Length);
        string selectedPrompt = prompts[promptIndex];
        Console.WriteLine("List as many items as you can for the following category:");
        Console.WriteLine(selectedPrompt);

        // Prompts the user to enter the duration for the activity
        Console.Write("Enter the duration for the listing activity (in seconds): ");
        _duration = Convert.ToInt32(Console.ReadLine());

        // Perform the listing activity
        PerformListingActivity(selectedPrompt);
    }

    private void PerformListingActivity(string prompt)
    {
        Console.Clear();
        Console.WriteLine("Get ready to start the listing activity...");
        Console.WriteLine("Press 'enter' when you are ready to start.");
        // Wait for the user to press 'enter'
        Console.ReadLine();

        int remainingTime = _duration;
        int itemsListed = 0;
        bool activityEnded = false;

        // Timer thread to update the remaining time
        Thread countdownThread = new Thread(() =>
        {
            while (remainingTime > 0 && !activityEnded)
            {
                // Waits for 1 second
                Thread.Sleep(1000);
                remainingTime--;

                // Save the current cursor position
                int cursorLeft = Console.CursorLeft;
                int cursorTop = Console.CursorTop;

                // Update the countdown timer display at the top
                Console.SetCursorPosition(0, 0);
                Console.Write("Time remaining: " + remainingTime + " seconds".PadRight(Console.WindowWidth - 1));

                // Display the prompt
                Console.SetCursorPosition(0, 1);
                Console.Write(prompt.PadRight(Console.WindowWidth - 1));

                // Restore the cursor position
                Console.SetCursorPosition(cursorLeft, cursorTop);
            }
            // Signal to end the activity when the time has expired
            activityEnded = true; 
        });

        countdownThread.Start();

        // Main thread to handle user input
        while (!activityEnded)
        {
            Console.SetCursorPosition(0, 3 + itemsListed);
            Console.Write("Enter an item: ");
            Console.SetCursorPosition(0, 4 + itemsListed);
            Console.Write("> ");

            // Check if remaining time is zero to end the input loop
            if (remainingTime <= 0)
            {
                activityEnded = true;
                break;
            }

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                activityEnded = true;
                break;
            }

            itemsListed++;
        }
        // Wait for the countdown thread to finish
        countdownThread.Join();

        Console.Clear();
        Console.WriteLine("Listing activity complete! You listed " + itemsListed + " items.");
    }
}
