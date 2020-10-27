using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {    
        public Book(string name)
        {
            grades = new List<double>();
            this.Name = name; // could also get rid of this keyword
        }

        public void AddLetterGrade(char letter) {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0) {
                grades.Add(grade);
            } else {
                Console.WriteLine("Invalid value");
            }
            
        }

        public Statistics GetStatistics() {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            
            // foreach(double grade in grades) {
            //     result.Low = Math.Min(grade, result.Low);
            //     result.High = Math.Max(grade, result.High);
            //     result.Average += grade;
            // }

            for(int index = 0; index < grades.Count; index++) {
                if (grades[index] == 42.1) {
                    // break;
                    // continue;
                }

                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
            }

            // var index = 0;

            // while (index < grades.Count) {
            //     result.Low = Math.Min(grades[index], result.Low);
            //     result.High = Math.Max(grades[index], result.High);
            //     result.Average += grades[index];

            //     index++;
            // }

            // do while loops always execute at least once
            // do
            // {
            //     result.Low = Math.Min(grades[index], result.Low);
            //     result.High = Math.Max(grades[index], result.High);
            //     result.Average += grades[index];

            //     index++;
            // } while (index < grades.Count);

            result.Average /= grades.Count;

            return result;
        }

        private List<double> grades;
        public string Name;
    }
}