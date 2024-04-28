using System;
using System.Data;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        // Console.Write("What is your magic number? ");
        // int magic_number = int.Parse(Console.ReadLine());
        Random randomGenerator = new Random();
        int magic_number = randomGenerator.Next(1, 100);
        int guess_number = -1;
        int num_guesses = 0;

        while (guess_number != magic_number)
        {
            Console.Write("What is your guess? (between 1 and 100) ");
            guess_number = int.Parse(Console.ReadLine());
            num_guesses++;
            if (magic_number > guess_number)
            {
                Console.WriteLine("Higher");
            }
            else if (magic_number < guess_number)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine($"You guessed it in {num_guesses} tries!");
            }
        }
    }
}
