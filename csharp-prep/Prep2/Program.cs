using System;

namespace prep2
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Write("What is your grade percentage? ");
            string percentage = Console.ReadLine();
            int grade_percent = int.Parse(percentage);
            string letter_grade = "";
            string sign = "";
            int last_digit = grade_percent % 10;

            if (last_digit <= 3)
            {
                sign = "-";
            }
            else if (last_digit >= 7)
            {
                sign = "+";
            }

            if (grade_percent >= 90)
            {
                letter_grade = "A";
                if (last_digit >= 7)
                {
                    sign = "";
                }
            }
            else if (grade_percent >= 80)
            {
                letter_grade = "B";
            }
            else if (grade_percent >= 70)
            {
                letter_grade = "C";
            }
            else if (grade_percent >= 60)
            {
                letter_grade = "D";
            }
            else
            {
                letter_grade = "F";
                sign = "";
            }

            Console.WriteLine($"Your letter grade is: {letter_grade}{sign}");
        }
    }
}