using System;

// Class responsible for generating random questions
public class QuestionAsker
{
    // List to store used questions to avoid repeats
    private static List<string> usedQuestions = new List<string>();  
    // Persist used questions to maintain question history

    // Method to generate a random question
    public static string GetRandomQuestion()
    {
        // Array of predefined questions
        string[] questions = {
            "Who was the most interesting person you interacted with today?",
            "What was the best part of your day?",
            "How did you see the hand of the Lord in your life today?",
            "What was the strongest emotion you felt today?",
            "If you had one thing you could do over today, what would it be?",
            "What did you eat for lunch today?",
            "What scripture did you study today?",
            "What are you planning on doing tomorrow?",
            "What is worrying you right at this moment?",
            "How did you relax today?"
        };

        // Check if all questions have been used and reset if needed
        if (usedQuestions.Count == questions.Length)
        {
            // If all questions are used, reset the list
            usedQuestions.Clear();  
            Console.WriteLine("All questions have been asked. Resetting...");  
        }

        // Generate a random question that has not been used before
        Random random = new Random();
        // Declare a variable to store the selected question
        string question;
        // Loop to select a random question that has not been used before
        do
        {
            // Get a random question from the array
            question = questions[random.Next(questions.Length)];
        } 
        // Repeat until an unused question is found
        while (usedQuestions.Contains(question));

        // Add the question to the used questions list
        usedQuestions.Add(question);
        // Return the randomly selected question  
        return question;  
    }
}