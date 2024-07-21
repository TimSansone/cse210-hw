public class Bingo75Game : BingoGame
    {
        private List<BingoBall> calledBalls = new List<BingoBall>();
        private int _totalCalledCount;
        private decimal _totalMoneyCollected;
        private decimal _winningsPerWinner;
        private decimal _houseMoney;

        protected override void InitializeBalls()
        {
            for (int i = 1; i <= 75; i++)
            {
                _balls.Add(new BingoBall(GetBingoLetter(i), i));
            }
        }

        public override void StartGame()
        {
            ShuffleBalls();
            Console.Clear();
            Console.WriteLine("Let's play a game of Bingo!");
            Console.WriteLine();
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

            BingoBall nextBall = _balls.FirstOrDefault(ball => !ball._isCalled);
            if (nextBall != null)
            {
                nextBall._isCalled = true;
                calledBalls.Add(nextBall);
                _lastCalledBall = nextBall;
                DisplayHelper.RollBallAnimation(nextBall._letter + nextBall._number);
                _totalCalledCount++;
                DisplayCalledBalls(calledBalls);
                Console.Beep();
                CheckForBingo();
            }
            else
            {
                Console.WriteLine("All Bingo balls have been called.");
                Console.WriteLine("The game will now end.");
                Environment.Exit(0);
            }
        }

        protected override void CheckForBingo()
        {
            Console.WriteLine();
            Console.WriteLine("Has anyone called Bingo? (Enter 'Y' for Yes or 'N' for No): ");
            string response = InputHandler.WaitForValidYesNoResponse();

            if (response == "Y")
            {
                DisplayCalledBalls(calledBalls.OrderBy(ball => ball._number).ToList());
                Console.WriteLine();
                Console.WriteLine("Please verify the Bingo card of the person/people that called Bingo.");
                Console.WriteLine("Did you verify the Bingo is valid? (Enter 'Y' for Yes or 'N' for No): ");
                string verifyResponse = InputHandler.WaitForValidYesNoResponse();

                if (verifyResponse == "Y")
                {
                    Console.WriteLine("Congratulations to the Bingo winner(s).");
                    Console.WriteLine();
                    Console.WriteLine("Here are the balls that were called during this game:");
                    Console.WriteLine();
                    DisplayCalledBalls(calledBalls.OrderBy(ball => ball._number).ToList());

                    Console.WriteLine();
                    Console.WriteLine("The total number of balls called was " + _totalCalledCount + ".");
                    Console.WriteLine();

                    int numberOfWinners = InputHandler.AskIntegerQuestion("How many people had a valid Bingo? ", 1);
                    _winningsPerWinner = (_totalMoneyCollected / 2) / numberOfWinners;
                    _houseMoney = (_totalMoneyCollected / 2);

                    Console.WriteLine($"The total money collected for this game was {_totalMoneyCollected:C}.");
                    Console.WriteLine($"The house receives: {_houseMoney:C}");
                    Console.WriteLine($"Each winner receives: {_winningsPerWinner:C}");
                    Console.WriteLine();

                    SaveGameResults(numberOfWinners);

                    Console.WriteLine("Thank you for playing Bingo!");
                    Console.WriteLine();

                    Console.WriteLine("Would you like to start another game? (Enter 'Y' for Yes or 'N' for No): ");
                    string newGameResponse = InputHandler.WaitForValidYesNoResponse();
                    if (newGameResponse == "Y")
                    {
                        Console.WriteLine("Great! Let's play another round of BINGO!");
                        ResetGame();
                        GameLauncher.StartNewGame();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("Since that was not a valid Bingo, let's continue the game.");
                    Console.WriteLine("Here comes the next Bingo ball.");
                    Console.WriteLine();
                    CallNextBall();
                }
            }
            else
            {
                Console.WriteLine("Okay, let's continue the game.");
                Console.WriteLine("Here comes the next Bingo ball.");
                Console.WriteLine();
                CallNextBall();
            }
        }

        private void SaveGameResults(int numberOfWinners)
        {
            string fileName = $"BingoGameResults_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("Ball,Number");
                foreach (var ball in calledBalls.OrderBy(ball => ball._number))
                {
                    writer.WriteLine($"{ball._letter},{ball._number}");
                }
                writer.WriteLine();
                writer.WriteLine($"Total Balls Called,{_totalCalledCount}");
                writer.WriteLine($"Total Money Collected,{_totalMoneyCollected:C}");
                writer.WriteLine($"House Money,{_houseMoney:C}");
                writer.WriteLine($"Number of Winners,{numberOfWinners}");
                writer.WriteLine($"Winnings Per Winner,{_winningsPerWinner:C}");
            }

            Console.WriteLine($"Game results saved to {fileName}");
        }

        private string GetBingoLetter(int number)
        {
            if (number >= 1 && number <= 15)
                return "B";
            if (number >= 16 && number <= 30)
                return "I";
            if (number >= 31 && number <= 45)
                return "N";
            if (number >= 46 && number <= 60)
                return "G";
            if (number >= 61 && number <= 75)
                return "O";
            return string.Empty;
        }
    }