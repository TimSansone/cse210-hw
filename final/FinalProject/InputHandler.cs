// Static class to handle user input
public static class InputHandler
{
    public static bool AskYesNoQuestion(string question)
    {
        Console.WriteLine(question);
        // Prompts user to answer yes/no question
        string response = WaitForValidYesNoResponse();
        return response == "Y";
    }

    public static int AskIntegerQuestion(string question, int defaultValue)
    {
        Console.WriteLine(question);
        if (int.TryParse(Console.ReadLine(), out int value))
        {
            // Prompts user to enter an integer value
            return value;
        }
        // Returns default value if input is invalid
        return defaultValue;
    }

    public static decimal AskDecimalQuestion(string question)
    {
        Console.WriteLine(question);
        decimal value;
        while (!decimal.TryParse(Console.ReadLine(), out value))
        {
            // Prompts user to enter a valid decimal number
            Console.WriteLine("Invalid input. Please enter a valid decimal number: ");
        }
        // Returns decimal value entered by the user
        return value;
    }

    public static string WaitForValidYesNoResponse()
    {
        string response;
        do
        {
            response = Console.ReadLine().Trim().ToUpper();
        } while (response != "Y" && response != "N");

        // Returns valid yes/no response entered by the user
        return response;
    }
}