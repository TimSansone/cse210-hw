// Abstract class representing a generic Bingo game
public abstract class BingoGame
{
    // List to store Bingo balls
    protected List<BingoBall> _balls;
    // Random number generator
    protected Random random = new Random();

    public BingoGame()
    {
        // Initializes the list of Bingo balls
        _balls = new List<BingoBall>();
        // Initializes Bingo balls based on game type (can be modified for game variations)
        InitializeBalls();
    }

    // Abstract method to initialize Bingo balls
    protected abstract void InitializeBalls();
    // Abstract method to start the game
    public abstract void StartGame();
    // Abstract method to call the next Bingo ball
    public abstract void CallNextBall();
    // Abstract method to check if Bingo has been called
    protected abstract void CheckForBingo();
}