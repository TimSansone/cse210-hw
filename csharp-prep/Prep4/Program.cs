using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        // Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int new_num = -1;
        while (new_num != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            string user_num = Console.ReadLine();
            new_num = int.Parse(user_num);
            if (new_num != 0)
            {
                numbers.Add(new_num);
            }
        }

        // Calculating sum of list
        int list_sum = 0;
        foreach (int num in numbers)
        {
            list_sum += num;    
        }
        Console.WriteLine($"The sum is: {list_sum}");

        // Calculating average
        float average = ((float)list_sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Calculating max number in the list
        int max_num = numbers[0];

        foreach (int num in numbers)
        {
            if (num > max_num)
            {
                max_num = num;
            }
        }
        Console.WriteLine($"The largest number is: {max_num}");
    }
}