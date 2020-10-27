using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // double[] numbers = new double[] { 12.7, 10.3, 6.11, 4.1};

            var book = new Book("Scott's Grade Book");
            // book.AddGrade(89.1);
            // book.AddGrade(90.5);
            // book.AddGrade(77.5);

            // var done = false;

            // while (!done) 
            while (true) 
            {
                Console.WriteLine("Enter a grade or 'q' to quit");

                var input = Console.ReadLine();

                if (input == "q") {
                    // done = true;
                    // continue;

                    break;
                }

                var grade = double.Parse(input);
                book.AddGrade(grade);
            }

            

            

            var stats = book.GetStatistics();
            
            Console.WriteLine($"The average grade is {stats.Average:N2}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }
    }
}
