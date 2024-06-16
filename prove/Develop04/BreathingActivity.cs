// Derived class for breathing activity
class BreathingActivity : Activity
{
    public override void StartActivity()
    {
        // Calls the base class method
        base.StartActivity();

        // Instructions for the breathing activity
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.");
        Console.WriteLine("Clear your mind and focus on your breathing.");

        // Prompt the user to enter the duration for the activity
        Console.WriteLine("Enter the duration for the breathing activity (in seconds): ");
        _duration = Convert.ToInt32(Console.ReadLine());
        // Implement breathing in and out logic here
        // Performs the CoolDown activity
        CoolDownTime();
    }
    private void CoolDownTime()
    {
        Console.WriteLine("Get ready to start the breathing activity...");

        // Perform the breathing activity exercise based on the user-selected duration
        int remainingTime = _duration;
        while (remainingTime > 0)
        {
            // Instructions for breathing in and out
            Console.WriteLine("Breathe in...");
            // Waits 4 seconds before continuing
            Thread.Sleep(4000);

            Console.WriteLine("Breathe out...");
            // Waits 4 seconds before continuing
            Thread.Sleep(4000);

            // Decrease the remaining time
            remainingTime -= 8;
        }
    }
}