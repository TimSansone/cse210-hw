// Manages a list of goals and provides methods to create, list, save, load, and record events for goals
    public class GoalManager
    {
        // List to store goals
        private List<Goal> _goals;

        public GoalManager()
        {
            _goals = new List<Goal>();
        }

        // Method to create a new goal
        public void CreateGoal()
        {
            Console.WriteLine("\nCreate a New Goal");
            Console.WriteLine("--------------------");
            Console.Write("Enter the goal name: ");
            string name = Console.ReadLine();

            Console.Write("Enter a short description of your goal: ");
            string description = Console.ReadLine();

            int points = GetIntInput("Enter the number of points to be awarded each time you reach this goal: ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nChoose the goal type:");
            Console.WriteLine("1. Simple Goal (Achieve a specific goal)");
            Console.WriteLine("2. Eternal Goal (Track progress)");
            Console.WriteLine("3. Checklist Goal (Complete a task multiple times)");
            Console.ResetColor();
            Console.Write("Choice: ");
            int goalType = GetIntInput("Choose a goal type (1, 2, or 3): ");

            // Create the appropriate goal type based on user input
            switch (goalType)
            {
                case 1:
                    _goals.Add(new SimpleGoal(name, description, points));
                    break;
                case 2:
                    _goals.Add(new EternalGoal(name, description, points));
                    break;
                case 3:
                    int targetCount = GetIntInput("How many times would you like to achieve this goal? ");
                    int bonusPoints = GetIntInput("How many bonus points should be awarded when you complete this goal? ");
                    _goals.Add(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        // Helper method to get a valid integer input from the user
        private int GetIntInput(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        // Method to list all goals with details
        public void ListGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals to display.");
            }
            else
            {
                Console.WriteLine("\nGoals:");
                foreach (Goal goal in _goals)
                {
                    // Barrier between goals
                    Console.WriteLine("-------------------------------");
                    string goalInfo = goal.GetGoalInfo();
                    string[] parts = goalInfo.Split(" - ");

                    // Highlighting specific parts of goal info
                    foreach (var part in parts)
                    {
                        if (part.StartsWith("Points:") || part.StartsWith("Score:"))
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(part);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine(part);
                        }
                    }

                    if (goal is ChecklistGoal checklistGoal)
                    {
                        Console.WriteLine(checklistGoal.GetProgressBar());
                    }
                }
                // Final Barrier
                Console.WriteLine("-------------------------------");
            }
        }

        // Method to save goals to a file
        public void SaveGoals()
        {
            Console.Write("Enter the filename to save goals to: ");
            string filename = Console.ReadLine();
            int goalCount = 0;
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (Goal goal in _goals)
                    {
                        writer.WriteLine(goal.Serialize());
                        goalCount++;
                    }
                }
                Console.WriteLine($"{goalCount} goals have been saved successfully to '{filename}'.");
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred while saving the goals.");
            }
        }

        // Method to load goals from a file
        public void LoadGoals()
        {
            Console.Write("Enter the filename to load goals from: ");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine($"File '{filename}' cannot be found.");
                return;
            }

            int goalCount = 0;
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        Goal goal = Goal.Deserialize(parts[0], line);
                        _goals.Add(goal);
                        goalCount++;
                    }
                }
                if (goalCount == 1)
                {
                    Console.WriteLine($"{goalCount} goal has been loaded successfully from '{filename}'.");
                }
                else
                {
                    Console.WriteLine($"{goalCount} goals have been loaded successfully from '{filename}'.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred while loading the goals.");
            }
        }

        // Method to record an event for a specific goal
        public void RecordEvent()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nCongratulations on getting closer to your goal!");
            Console.ResetColor();
            Console.Write("\nEnter the goal name to record an event: "); 
            string name = Console.ReadLine();
            Goal goal = _goals.Find(g => g.Name == name);

            if (goal != null)
            {
                goal.RecordEvent();
                Console.WriteLine("Event recorded.");
            }
            else
            {
                Console.WriteLine("Goal not found.");
            }
        }
    }
