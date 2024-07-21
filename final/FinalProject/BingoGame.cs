public abstract class BingoGame
    {
        protected List<BingoBall> _balls;
        protected Random random = new Random();
        protected BingoBall _lastCalledBall;

        protected BingoGame()
        {
            _balls = new List<BingoBall>();
            InitializeBalls();
        }

        protected abstract void InitializeBalls();
        public abstract void StartGame();
        public abstract void CallNextBall();
        protected abstract void CheckForBingo();

        protected void ShuffleBalls()
        {
            for (int i = _balls.Count - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                BingoBall temp = _balls[i];
                _balls[i] = _balls[j];
                _balls[j] = temp;
            }
        }

        protected void ResetGame()
        {
            _balls.Clear();
            InitializeBalls();
            ShuffleBalls();
        }

        protected void DisplayCalledBalls(List<BingoBall> calledBalls)
        {
            Console.WriteLine();
            if (_lastCalledBall != null)
            {
                Console.WriteLine($"The latest Bingo ball called was: {_lastCalledBall._letter}{_lastCalledBall._number}");
                Console.WriteLine();
            }

            Console.WriteLine("Here are all of the balls that have been called (in order they were called):");
            Console.WriteLine();
            foreach (var ball in calledBalls)
            {
                Console.Write($"{ball._letter}{ball._number} ");
            }
            Console.WriteLine();
        }
    }