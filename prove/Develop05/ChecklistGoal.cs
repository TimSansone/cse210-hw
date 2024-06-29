// Represents a checklist goal
    public class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonusPoints;

        public bool IsCompleted { get; private set; }

        // Constructor for ChecklistGoal
        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _bonusPoints = bonusPoints;
            _currentCount = 0;
        }

        // Overloaded constructor for deserialization
        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, int currentCount) 
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _bonusPoints = bonusPoints;
            _currentCount = currentCount;
        }

        // Record event for ChecklistGoal
        public override void RecordEvent()
        {
            if (!IsCompleted)
            {
                _currentCount++;
                Score += Points;
                if (_currentCount >= _targetCount)
                {
                    Score += _bonusPoints;
                    // Reset for further tracking
                    IsCompleted = true;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Congratulations! You have completed your goal!");
                    Console.ResetColor();
                    DisplayCelebration();
                }
            }
            else
            {
                Console.WriteLine("Goal requirements have already been met. No further points will be awarded.");
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

        // Get info for ChecklistGoal
        public override string GetGoalInfo()
        {
            return $"(Checklist Goal) - {Name} - {Description} - Points: {Points} - Score: {Score} - Progress: {_currentCount}/{_targetCount} - Bonus: {_bonusPoints}";
        }

        // Serialize ChecklistGoal
        public override string Serialize()
        {
            return $"ChecklistGoal;{Name};{Description};{Points};{Score};{_targetCount};{_bonusPoints};{_currentCount}";
        }

        // Display progress bar for ChecklistGoal
        public string GetProgressBar()
        {
            double percentage = (double)_currentCount / _targetCount;
            int totalBlocks = 20;
            int filledBlocks = (int)(percentage * totalBlocks);
            int emptyBlocks = totalBlocks - filledBlocks;

            ConsoleColor filledColor = ConsoleColor.Green;
            ConsoleColor emptyColor = ConsoleColor.DarkGray;

            ConsoleColor originalForeground = Console.ForegroundColor;
            ConsoleColor originalBackground = Console.BackgroundColor;

            Console.ForegroundColor = filledColor;
            Console.Write("[");
            Console.BackgroundColor = filledColor;
            Console.Write(new string(' ', filledBlocks));
            Console.BackgroundColor = emptyColor;
            Console.Write(new string(' ', emptyBlocks));
            Console.BackgroundColor = originalBackground;
            Console.Write("]");

            // Reset to original console colors
            Console.ForegroundColor = originalForeground;

            Console.WriteLine($" {percentage:P2} of your goal has been completed.");

            return string.Empty; // Adjust return type as per your needs
        }
    }