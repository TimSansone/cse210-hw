// Abstract base class for goals
    public abstract class Goal
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Points { get; private set; }
        public int Score { get; protected set; }

        // Constructor for Goal class
        protected Goal(string name, string description, int points)
        {
            Name = name;
            Description = description;
            Points = points;
            Score = 0;
        }

        // Abstract method to record an event
        public abstract void RecordEvent();
        // Abstract method to get goal info
        public abstract string GetGoalInfo();
        // Abstract method to serialize goal
        public abstract string Serialize();

        // Method to deserialize goal from a string
        public static Goal Deserialize(string type, string data)
        {
            string[] parts = data.Split(';');
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            int score = int.Parse(parts[4]);

            Goal goal = type switch
            {
                "SimpleGoal" => new SimpleGoal(name, description, points, bool.Parse(parts[5])),
                "EternalGoal" => new EternalGoal(name, description, points),
                "ChecklistGoal" => new ChecklistGoal(name, description, points, int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7])),
                _ => throw new Exception("Invalid goal type")
            };

            goal.Score = score;
            return goal;
        }
    }
