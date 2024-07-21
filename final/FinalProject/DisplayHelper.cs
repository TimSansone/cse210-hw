// Static class for display-related functionalities
public static class DisplayHelper
{
    // Prints the Bingo ball with a specific color
    public static void PrintColoredBall(string text)
    {
        Console.Write(text);
        Console.ResetColor();
    }

    // Displays a rolling ball animation
    public static void RollBallAnimation(string ballText)
    {
        string[] frames = new string[]
        {
            $@"
             
             
             
              -----
            /       \
           /         \
          |    {ballText.PadLeft(2)}    |
           \         /
            \       /
              -----
",
            $@"
             
             
              -----
            /       \
           /         \
          |    {ballText.PadLeft(2)}    |
           \         /
            \       /
              -----
",
            $@"
             
              -----
            /       \
           /         \
          |    {ballText.PadLeft(2)}    |
           \         /
            \       /
              -----             
",
            $@"
              -----
            /       \
           /         \
          |    {ballText.PadLeft(2)}    |
           \         /
            \       /
              -----                     
",
            $@"
             
              -----
            /       \
           /         \
          |    {ballText.PadLeft(2)}    |
           \         /
            \       /
              -----             
             
",
            $@"
             
             
              -----
            /       \
           /         \
          |    {ballText.PadLeft(2)}    |
           \         /
            \       /
              -----             
"
        };

        Console.Clear();
        for (int i = 0; i < 3; i++)
        {
            foreach (string frame in frames)
            {
                Console.Clear();
                Console.WriteLine(frame);
                Thread.Sleep(200);
            }
        }
    }
}