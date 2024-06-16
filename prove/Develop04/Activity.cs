// Base class for activities
class Activity
{
    public string _name { get; set; }
    public string _description { get; set; }
    public int _duration { get; set; }

    // Virtual method to start the activity, can be overridden in derived classes
    public virtual void StartActivity()
    {
        Console.WriteLine($"Starting {_name} activity for {_duration} seconds.");
        
    }
    // Virtual method to end the activity, can be overridden in derived classes
    public virtual void EndActivity()
    {
        // Ending logic for activities
        Console.WriteLine($"You've completed the {_name} activity for {_duration} seconds.");
        Console.WriteLine("You did a great job!");
        
    }
}