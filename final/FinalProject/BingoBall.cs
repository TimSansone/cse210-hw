// Class representing a Bingo ball
public class BingoBall
{
    // Letter associated with the Bingo ball
    public string _letter { get; }
    // Number of the Bingo ball
    public int _number { get; }
    // Status of whether the Bingo ball has been called
    public bool _isCalled { get; set; }

    public BingoBall(string letter, int number)
    {
        // Initializes the Bingo ball with it's associated letter
        _letter = letter;
        // Initializes the Bingo ball with it's associated number
        _number = number;
        // Initializes the Bingo ball as not called
        _isCalled = false;
    }
}