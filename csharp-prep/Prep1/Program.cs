using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string first_name = Console.ReadLine();
        first_name = char.ToUpper(first_name[0]) + first_name.Substring(1);

        Console.Write("What is your last name? ");
        string last_name = Console.ReadLine();
        last_name = char.ToUpper(last_name[0]) + last_name.Substring(1);


        Console.WriteLine($"Your name is {last_name}, {first_name} {last_name}.");
        }
}