using System;
using System.Threading;

// Derived class jfor reflection activity
class ReflectionActivity : Activity
{
    private string[] prompts = new string[]
    {
        "Think of a time when you stood up for someone else",
        "Think of a time when you did something really difficult",
        "Think of a time when you helped someone in need",
        "Think of a time when you did something truly selfless"
    };

    private string[] reflectionQuestions = new string[]
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public override void StartActivity()
    {
        // Call the base class method
        base.StartActivity();

        // Instructions for the reflection activity
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
        Console.WriteLine("This will help you recognize your power and how you can use it in other aspects of your life.");

        // Prompt the user to enter the duration for the activity
        Console.Write("Enter the duration for the reflection activity (in seconds): ");
        _duration = Convert.ToInt32(Console.ReadLine());

        // Perform the reflection activity
        PerformReflectionActivity();
    }

    private void PerformReflectionActivity()
{
    Console.WriteLine("Get ready to start the reflection activity...");
    Console.WriteLine("Press 'enter' when you are ready to start.");
    // Allows the program to wait for the user to hit 'enter'
    Console.ReadLine();

    int totalTime = _duration;
    int remainingTime = totalTime;

    Random rnd = new Random();
        int promptIndex = rnd.Next(prompts.Length);
        Console.WriteLine(prompts[promptIndex]);

        int questionIndex = 0;

        while (remainingTime > 0 && questionIndex < reflectionQuestions.Length)
        {
            Console.WriteLine("Time remaining: " + remainingTime + " seconds");

            if (questionIndex > 0)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 2);
                Console.Write(new string(' ', Console.WindowWidth));
            }

            Console.Clear();
            Console.WriteLine(reflectionQuestions[questionIndex]);
            Console.WriteLine("");

            for (int seconds = 15; seconds > 0 && remainingTime > 0; seconds--)
            {
                // Move cursor up to update countdown
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                // Ensures that text will be displayed at a consistent width
                Console.WriteLine("Time remaining: " + remainingTime.
                ToString().PadLeft(3) + " seconds");
                remainingTime--;
                // Allows the program to wait for 1 second before continuing
                Thread.Sleep(1000);

                if (remainingTime <= 0)
                {
                    break;
                }
            }

            questionIndex++;
        }

    Console.SetCursorPosition(0, Console.CursorTop);
    // Clears the last countdown line
    Console.Write(new string(' ', Console.WindowWidth + 1));
    Console.SetCursorPosition(0, Console.CursorTop);
    Console.WriteLine("Reflection activity complete!");
}

}
