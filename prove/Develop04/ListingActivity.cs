using System;
using System.Collections.Generic;
using System.Threading;

class ListingActivity : Activity
{
    private string[] prompts = new string[]
    {
        "List as many fruits as you can",
        "List as many animals as you can",
        "List as many countries as you can",
        "List as many movies as you can"
    };

    private Dictionary<string, int> leaderboard = new Dictionary<string, int>();

    public override void StartActivity()
    {
        base.StartActivity();

        Random rnd = new Random();
        int promptIndex = rnd.Next(prompts.Length);
        string selectedPrompt = prompts[promptIndex];
        Console.WriteLine("List as many items as you can for the following category:");
        Console.WriteLine(selectedPrompt);

        if (leaderboard.ContainsKey(selectedPrompt))
        {
            Console.WriteLine($"Current highest score for this category: {leaderboard[selectedPrompt]} items");
        }

        Console.Write("Enter the duration for the listing activity (in seconds): ");
        _duration = Convert.ToInt32(Console.ReadLine());

        PerformListingActivity(selectedPrompt);
    }

    private void PerformListingActivity(string prompt)
    {
        Console.Clear();
        Console.WriteLine("Get ready to start the listing activity...");
        Console.WriteLine("Press 'enter' when you are ready to start.");
        Console.ReadLine();

        int remainingTime = _duration;
        int itemsListed = 0;
        bool activityEnded = false;

        // Start the countdown thread
        Thread countdownThread = new Thread(() =>
        {
            while (remainingTime > 0 && !activityEnded)
            {
                Thread.Sleep(1000);
                remainingTime--;

                // Lock console updates to avoid conflicts
                lock (Console.Out)
                {
                    UpdateTimerDisplay(remainingTime);
                }

                if (remainingTime <= 0)
                {
                    activityEnded = true;
                }
            }
        });

        countdownThread.Start();

        // Input items listed by the user
        while (!activityEnded)
        {
            lock (Console.Out)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine(prompt.PadRight(Console.WindowWidth)); // Display the prompt
                Console.SetCursorPosition(0, 4 + itemsListed);
                Console.Write("> ");
                Console.SetCursorPosition(3, 4 + itemsListed); // Position cursor for user input
            }

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

        countdownThread.Join();

        Console.Clear();
        Console.WriteLine("Listing activity complete! You listed " + itemsListed + " items.");

        if (!leaderboard.ContainsKey(prompt) || itemsListed > leaderboard[prompt])
        {
            leaderboard[prompt] = itemsListed;
            Console.WriteLine("Congratulations! You set a new high score for this category.");
        }
    }

    private void UpdateTimerDisplay(int remainingTime)
    {
        int currentLineCursor = Console.CursorTop;
        int currentColCursor = Console.CursorLeft;

        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Time remaining: {remainingTime} seconds".PadRight(Console.WindowWidth));
        Console.ResetColor();
        DisplayProgressBar(remainingTime);

        // Restore the cursor position after updating the timer display
        Console.SetCursorPosition(currentColCursor, currentLineCursor);
    }

    private void DisplayProgressBar(int remainingTime)
    {
        int totalLength = 30;
        int filledLength = totalLength * remainingTime / _duration;

        Console.SetCursorPosition(0, 1);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("[");
        for (int i = 0; i < totalLength; i++)
        {
            if (i < filledLength)
                Console.Write("=");
            else
                Console.Write(" ");
        }
        Console.Write("]");
        Console.ResetColor();
    }
}
