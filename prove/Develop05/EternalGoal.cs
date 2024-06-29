// Represents an eternal goal
    public class EternalGoal : Goal
    {
        // Constructor for EternalGoal
        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        {
        }

        // Record info for EternalGoal
        public override void RecordEvent()
        {
            Score += Points;
        }

        // Get info for EternalGoal
        public override string GetGoalInfo()
        {
            return $"(Eternal Goal) - {Name} - {Description} - Points: {Points} - Score: {Score}";
        }

        // Serialize EternalGoal
        public override string Serialize()
        {
            return $"EternalGoal;{Name};{Description};{Points};{Score}";
        }
    }