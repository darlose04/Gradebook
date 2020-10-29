using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get; set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null) {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }

    public class InMemoryBook : Book, IBook
    {    
        public InMemoryBook(string name) : base(name)
        {
            // category = "";
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

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0) {
                grades.Add(grade);
                if (GradeAdded != null) {
                    GradeAdded(this, new EventArgs());
                }
            } else {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
            
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics() {
            var result = new Statistics();
            // result.Average = 0.0;
            // result.High = double.MinValue;
            // result.Low = double.MaxValue;
            
            // foreach(double grade in grades) {
            //     result.Low = Math.Min(grade, result.Low);
            //     result.High = Math.Max(grade, result.High);
            //     result.Average += grade;
            // }

            for(var index = 0; index < grades.Count; index++) {
                result.Add(grades[index]);

                // result.Low = Math.Min(grades[index], result.Low);
                // result.High = Math.Max(grades[index], result.High);
            }

            // result.Average /= grades.Count;

            // for(int index = 0; index < grades.Count; index++) {
            //     if (grades[index] == 42.1) {
            //         // break;
            //         // continue;
            //     }

            //     result.Low = Math.Min(grades[index], result.Low);
            //     result.High = Math.Max(grades[index], result.High);
            //     result.Average += grades[index];
            // }

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

            // result.Average /= grades.Count;

            // switch(result.Average)
            // {
            //     case var d when d >= 90.0:
            //         result.Letter = 'A';
            //         break;
            //     case var d when d >= 80.0:
            //         result.Letter = 'B';
            //         break;
            //     case var d when d >= 70.0:
            //         result.Letter = 'C';
            //         break;
            //     case var d when d >= 60.0:
            //         result.Letter = 'D';
            //         break;
            //     default:
            //         result.Letter = 'F';
            //         break;
            // }

            return result;
        }

        private List<double> grades;

        // long way of defining properties
        // public string Name
        // {
        //     get
        //     {
        //         return name;
        //     }
        //     set
        //     {
        //         if (!String.IsNullOrEmpty(value))
        //         {
        //             name = value;
        //         }
        //     }
        // }
        // private string name;

        // auto property
        // public string Name
        // {
        //     get; 
        //     // read only property
        //     set;
        // }

        // can only use this in the constructor or to assign a value here (variable initializer)
        // readonly string category = "Science";
        // const string category = "Science";
        
        public const string CATEGORY = "Science";
        
    }
}