public static class GameLauncher
    {
        public static void StartNewGame()
        {
            BingoGame game = new Bingo75Game();
            game.StartGame();
            game.CallNextBall();
        }
    }
