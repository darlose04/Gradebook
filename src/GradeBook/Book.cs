using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {    
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStatistics() {
            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            
            foreach(double number in grades) {
                lowGrade = Math.Min(number, lowGrade);
                highGrade = Math.Max(number, highGrade);
                result += number;
            }

            double avg = result / grades.Count;
            Console.WriteLine($"The average grade is {avg:N2}");
            Console.WriteLine($"The lowest grade is {lowGrade}");
            Console.WriteLine($"The highest grade is {highGrade}");
        }

        private List<double> grades;
        private string name;
    }
}