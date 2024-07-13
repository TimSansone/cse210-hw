// Static class to handle display-related tasks
public static class DisplayHelper
{
    public static void RollBallAnimation(string ballText)
    {
        string[] frames = new string[]
        {
            $@"
             
             
             
              ______
            /       \
           |   {ballText.PadLeft(2)}   |
            \_______/
",
            $@"
             
             
              ______
            /       \
           |   {ballText.PadLeft(2)}   |
            \_______/
             
",
            $@"
             
              ______
            /       \
           |   {ballText.PadLeft(2)}   |
            \_______/
             
             
",
            $@"
              ______
            /       \
           |   {ballText.PadLeft(2)}   |
            \_______/
             
             
             
",
            $@"
             
              ______
            /       \
           |   {ballText.PadLeft(2)}   |
            \_______/
             
             
",
            $@"
             
             
              ______
            /       \
           |   {ballText.PadLeft(2)}   |
            \_______/
             
",
            $@"
             
             
             
              ______
            /       \
           |   {ballText.PadLeft(2)}   |
            \_______/
",
            $@"
             
             
              ______
            /       \
           |   {ballText.PadLeft(2)}   |
            \_______/
             
",
            $@"
             
              ______
            /       \
           |   {ballText.PadLeft(2)}   |
            \_______/
             
             
",
            $@"
              ______
            /       \
           |   {ballText.PadLeft(2)}   |
            \_______/
             
             
             
"
        };

        Console.Clear();
        Console.WriteLine("Bouncing the ball...");
        for (int i = 0; i < 3; i++)
        {
            foreach (string frame in frames)
            {
                Console.Clear();
                Console.WriteLine(frame);
                // Adjusts the speed of the animation
                Thread.Sleep(200);
            }
        }
        Console.Clear();
        Console.WriteLine($"The ball is: {ballText}");
        Console.WriteLine();
    }

    public static void PrintColoredBall(string ballText)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(ballText);
        Console.ResetColor();
    }

    public static void DisplayCountdown(int seconds)
    {
        Console.WriteLine("The next ball is being selected.");
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"***{i}***");
            // Adjusts the speed of the countdown (1 second)
            Thread.Sleep(1000);
        }
    }
}