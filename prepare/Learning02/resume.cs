using System;

public class Resume
{
    public string _fullname;

    // Initializing list
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.ResetColor();
        Console.Clear();
        Console.WriteLine($"Name: {_fullname}");
        Console.WriteLine("Jobs:");

        // Notice the use of the custom data type "Job" in this loop
        foreach (Job job in _jobs)
        {
            // Calls Display() function to display each job
            Console.ForegroundColor = ConsoleColor.Blue;
            job.Display();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("****************************************************************************");
            Console.ResetColor();
        }
    }
}