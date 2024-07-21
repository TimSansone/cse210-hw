public static class InputHandler
    {
        public static decimal AskDecimalQuestion(string question)
        {
            Console.Write(question);
            return decimal.Parse(Console.ReadLine());
        }

        public static int AskIntegerQuestion(string question, int minValue)
        {
            int result;
            do
            {
                Console.Write(question);
                result = int.Parse(Console.ReadLine());
            } while (result < minValue);
            return result;
        }

        public static string WaitForValidYesNoResponse()
        {
            string response;
            do
            {
                response = Console.ReadLine().ToUpper();
            } while (response != "Y" && response != "N");
            return response;
        }
    }