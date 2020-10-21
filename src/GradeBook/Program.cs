using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // double[] numbers = new double[] { 12.7, 10.3, 6.11, 4.1};

            var Book = new Book();
            Book.AddGrade(89.1);
            Book.AddGrade(90.5);
            
            List<double> grades = new List<double>() { 12.7, 10.3, 6.11, 4.1};
            grades.Add(56.1);

            var result = 0.0;
            foreach(double number in grades) {
                result += number;
            }
            double avg = result / grades.Count;
            Console.WriteLine($"The average grade is {avg:N2}");
        }
    }
}
