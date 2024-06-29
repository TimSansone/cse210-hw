// Represents a simple goal
    public class SimpleGoal : Goal
    {
        private bool _isCompleted;

        // Constructor for SimpleGoal
        public SimpleGoal(string name, string description, int points)
            : base(name, description, points)
        {
            _isCompleted = false;
        }

        // Overloaded constructor for deserialization
        public SimpleGoal(string name, string description, int points, bool isCompleted) : base(name, description, points)
        {
            _isCompleted = isCompleted;
        }

        // Record event for SimpleGoal
        public override void RecordEvent()
        {
            if (!_isCompleted)
            {
                Score = Points;
                _isCompleted = true;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Congratulations! You have completed your goal!");
                Console.ResetColor();
                DisplayCelebration();
            }
        }

        private void DisplayCelebration()
        {
            Console.WriteLine(@"
            ****************************
            *        Well Done!        *
            *  You achieved your goal! *
            ****************************
            ");
        }

        // Get info for SimpleGoal
        public override string GetGoalInfo()
        {
            return $"(Simple Goal) - {Name} - {Description}  - Points: {Points} - Score: {Score} - Completed: {_isCompleted}";
        }

        // Serialize SimpleGoal
        public override string Serialize()
        {
            return $"SimpleGoal;{Name};{Description};{Points};{Score};{_isCompleted}";
        }
    }