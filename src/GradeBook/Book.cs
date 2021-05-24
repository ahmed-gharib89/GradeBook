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
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        void ShowStatistics(Statistics result);
        string Name { get;}
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
            
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();

        public abstract void ShowStatistics(Statistics result);
    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades  = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter)
        {
            switch (letter)
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
                default:
                    AddGrade(0);
                    break;
            }
            
        }
        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);

                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            for (var i = 0; i < grades.Count; i++)
            {
                result.Add(grades[i]);
            }

            return result;
        }
        public override void ShowStatistics(Statistics result)
        {
            Console.WriteLine($"The average grade is: {result.Average:N1}");
            Console.WriteLine($"The highest grade is: {result.High:N}");
            Console.WriteLine($"The lowest grade is: {result.Low:N}");
            Console.WriteLine($"The letter grade is: {result.Letter}");
        }

        private List<double> grades;
    }


    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
            Name = name;
        }

        public override event GradeAddedDelegate GradeAdded;
        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                using(var writer = File.AppendText($"{Name}.txt"))
                {
                    writer.WriteLine(grade);
                }
                
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using(var reader = File.OpenText($"{Name}.txt"))
            {
                while(true)
                {
                    if (reader.ReadLine() == null)
                    {
                        break;
                    }
                    var grade = double.Parse(reader.ReadLine());
                    result.Add(grade);
                }
            }
            return result;
        }
        public override void ShowStatistics(Statistics result)
        {
            Console.WriteLine($"The average grade is: {result.Average:N1}");
            Console.WriteLine($"The highest grade is: {result.High:N}");
            Console.WriteLine($"The lowest grade is: {result.Low:N}");
            Console.WriteLine($"The letter grade is: {result.Letter}");
        }
    }

}