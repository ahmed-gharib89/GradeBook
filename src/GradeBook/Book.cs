using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades  = new List<double>();
            this.name = name;
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            foreach (var num in grades)
            {
                result.High = Math.Max(num, result.High);

                result.Low = Math.Min(num, result.Low);

                result.Average += num;
            }

            result.Average /= grades.Count;
            return result;
        }

        public void ShowStatistics(Statistics result)
        {
            Console.WriteLine($"The average grade is: {result.Average:N1}\nThe highest grade is: {result.High:N}\nThe lowest grade is: {result.Low:N}");

        }

        public string GetName()
        {
            return name;
        }

        private List<double> grades;
        private string name;
    }
}