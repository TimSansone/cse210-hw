// Class representing a 75-ball Bingo game
public class Bingo75Game : BingoGame
{
    // List to store called Bingo balls
    private List<BingoBall> calledBalls = new List<BingoBall>();

    // Total number of Bingo balls called
    private int _totalCalledCount;

    // Total money collected for the game
    private decimal _totalMoneyCollected;

    // Winnings per winner
    private decimal _winningsPerWinner;

    // Money collected by the house
    private decimal _houseMoney;

    protected override void InitializeBalls()
    {
        for (int i = 1; i <= 75; i++)
        {
            // Adds 75 bingo balls with their respective letters and numbers
            _balls.Add(new BingoBall(GetBingoLetter(i), i));
        }
    }

    public override void StartGame()
    {
        // Shuffles the Bingo balls
        ShuffleBalls();
        // Prompt the user to enter the total money that was collected for the game
        _totalMoneyCollected = InputHandler.AskDecimalQuestion("Enter the total money collected for the game: ");
    }

    public override void CallNextBall()
    {
        if (_totalCalledCount == 0)
        {
            Console.WriteLine("Press Enter to call the first Bingo ball...");
            Console.ReadLine();
            Console.WriteLine("Here comes the first Bingo ball of the game.");
            Console.WriteLine();
        }

        // Finds the next Bingo ball that has not been called
        BingoBall nextBall = _balls.FirstOrDefault(ball => !ball._isCalled);
        if (nextBall != null)
        {
            // Marks the Bingo ball as called
            nextBall._isCalled = true;
            // Adds the called ball to the list of called balls
            calledBalls.Add(nextBall);
            // Displays the animation for the next called Bingo ball
            DisplayHelper.RollBallAnimation(nextBall._letter + nextBall._number);
            // Plays a beep sound
            SoundHelper.PlayBeep();
            // Increments the total number of called balls
            _totalCalledCount++;
            // Displays all of the balls that have been called
            DisplayCalledBalls();
            // Checks if anyone has called Bingo yet
            CheckForBingo();
        }
        else
        {
            Console.WriteLine("All bingo balls have been called.");
            Console.WriteLine("The game will now end.");
            // Exits the game if all 75 Bingo balls have been called
            Environment.Exit(0);
        }
    }

    protected override void CheckForBingo()
    {
        Console.WriteLine();
        Console.WriteLine("Has anyone called Bingo? (Enter 'Y' for Yes or 'N' for No): ");
        // Prompts the user to check if anyone has called Bingo yet
        string response = InputHandler.WaitForValidYesNoResponse();

        if (response == "Y")
        {
            // Displays all of the called balls in numerical order
            DisplayCalledBallsSorted();
            Console.WriteLine();
            Console.WriteLine("Please verify the Bingo card of the person/people that called Bingo.");
            Console.WriteLine("Did you verify the Bingo is valid? (Enter 'Y' for Yes or 'N' for No): ");
            // Prompts the user to verify that the Bingo is valid
            string verifyResponse = InputHandler.WaitForValidYesNoResponse();

            if (verifyResponse == "Y")
            {
                Console.WriteLine("Congratulations to the Bingo winner(s).");
                Console.WriteLine();
                Console.WriteLine("Here are the balls that were called during this game:");
                Console.WriteLine();
                // Displays all of the called balls in numerical order
                DisplayCalledBallsSorted();

                Console.WriteLine();
                Console.WriteLine("The total number of balls called was " + _totalCalledCount + ".");
                Console.WriteLine();

                // Prompts the user to enter the number of people that had a valid Bingo
                int numberOfWinners = InputHandler.AskIntegerQuestion("How many people had a valid Bingo? ", 1);
                // Calculate the winnings that each winner should receive (50% of totalMoneyCollected/numberOfWinners)
                _winningsPerWinner = (_totalMoneyCollected / 2) / numberOfWinners;
                // Calculates the money that goes to the house (50% of totalMoneyCollected)
                _houseMoney = (_totalMoneyCollected / 2);

                Console.WriteLine($"The total money collected for this game was {_totalMoneyCollected:C}.");
                Console.WriteLine($"The house receives: {_houseMoney:C}");
                Console.WriteLine($"Each winner receives: {_winningsPerWinner:C}");
                Console.WriteLine();

                // Saves the game results to a CSV file
                SaveGameResults(numberOfWinners);

                Console.WriteLine("Thank you for playing Bingo!");
                Console.WriteLine();

                Console.WriteLine("Would you like to start another game? (Enter 'Y' for Yes or 'N' for No): ");
                // Prompts the user to start another game or not
                string newGameResponse = InputHandler.WaitForValidYesNoResponse();
                if (newGameResponse == "Y")
                {
                    Console.WriteLine("Great! Let's play another round of BINGO!");
                    // Resets game data for a new game
                    ResetGame();
                    // Starts a new game
                    GameLauncher.StartNewGame();
                }
                else
                {
                    // Exits the program if the user chooses not to start another game
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("Since that was not a valid Bingo, let's continue the game.");
                Console.WriteLine("Here comes the next Bingo ball.");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Here comes the next Bingo ball.");
            Console.WriteLine();
        }
    }

    private void SaveGameResults(int numberOfWinners)
    {
        // File path to save game results
        string filePath = "bingo.csv";

        // Fromat date and time
        string timestamp = DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine("Date and Time, Balls Called, Total Money Collected, Winnings Per Winner, Number of Winners");
            // Writes game results to the CSV file
            writer.WriteLine($"{timestamp}, {string.Join(", ", calledBalls.Select(ball => ball.
            _letter + ball._number))}, {_totalMoneyCollected:C}, {_winningsPerWinner:C}, {numberOfWinners}");
        }
    }

    private void DisplayCalledBalls()
    {
        Console.WriteLine();
        Console.WriteLine("Here are all of the balls that have been called (in order they were called):");
        Console.WriteLine();
        foreach (var ball in calledBalls)
        {
            // Displays each called ball in order that ball was called
            DisplayHelper.PrintColoredBall(ball._letter + ball._number + " ");
        }
        Console.WriteLine();
    }

    private void DisplayCalledBallsSorted()
    {
        // Sorts called balls by numer
        var sortedBalls = calledBalls.OrderBy(ball => ball._number).ToList();
        Console.WriteLine("Here are all of the balls that were called (in numerical order):");
        Console.WriteLine();
        foreach (var ball in sortedBalls)
        {
            // Displays each sorted ball
            DisplayHelper.PrintColoredBall(ball._letter + ball._number + " ");
        }
        Console.WriteLine();
    }

    private void ShuffleBalls()
    {
        for (int i = _balls.Count - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            BingoBall temp = _balls[i];
            // Shuffle Bingo balls randomly
            _balls[i] = _balls[j];
            _balls[j] = temp;
        }
    }

    private string GetBingoLetter(int number)
    {
        return number switch
        {
            // Assigns letter 'B' to numbers 1-15
            >= 1 and <= 15 => "B",
            // Assigns letter 'I' to numbers 16-30 
            >= 16 and <= 30 => "I",
            // Assigns letter 'N' to numbers 31-45
            >= 31 and <= 45 => "N",
            // Assigns letter 'G' to numbers 46-60
            >= 46 and <= 60 => "G",
            // Assigns letter 'O' to numbers 61-75
            _ => "O",
        };
    }

    private void ResetGame()
    {
        // Clears calledBalls list
        calledBalls.Clear();
        foreach (var ball in _balls)
        {
            // Resets called status of each Bingo ball
            ball._isCalled = false;
        }
        // Resets total number of called balls
        _totalCalledCount = 0;
        // Shuffles the Bingo balls for the new game
        ShuffleBalls();
    }
}