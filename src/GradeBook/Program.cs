using System.Reflection;
using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var book = new Book("Gharib Grade Book");
            book.GradeAdded += OneGradeAdded;
            book.GradeAdded += OneGradeAdded;
            book.GradeAdded -= OneGradeAdded;
            book.GradeAdded += OneGradeAdded;
            
            while (true)
            {
                Console.WriteLine("Please enter a grade or Q to quit");
                var input = Console.ReadLine();
                if (input.ToLower() == "q"  || input.ToLower() == "quit")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                     Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                     Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("***********");
                }
            }

            Console.WriteLine($"for book named: {book.Name}");
            var result = book.GetStatistics();
            book.ShowStatistics(result);

        }
        static void OneGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A Grade was added");
        }
    }
}
