// Static class to handle launching the game
public static class GameLauncher
{
    public static void StartNewGame()
    {
        Console.Clear();
        Console.WriteLine("Let's play BINGO!");
        Console.WriteLine("Press Enter to start the game.");
        Console.ReadLine();

        // Start a new 75-Ball Bingo game
        BingoGame game = new Bingo75Game();
        // Initializes the game
        game.StartGame();

        bool autoCall = InputHandler.AskYesNoQuestion("Would you like to auto-call balls? (Y or N): ");
        int autoCallInterval = 0;

        if (autoCall)
        {
            autoCallInterval = InputHandler.AskIntegerQuestion("Enter the interval in seconds between auto-calls: ", 5); // Set auto-call interval if user chooses to auto-call balls
        }

        while (true)
        {
            // Calls the next Bingo ball
            game.CallNextBall();
            if (autoCall)
            {
                // Displays countdown between auto-calls, if auto-call is enabled
                DisplayHelper.DisplayCountdown(autoCallInterval);
            }
            else
            {
                Console.WriteLine("Press Enter to call the next ball...");
                Console.ReadLine();
            }
        }
    }
}