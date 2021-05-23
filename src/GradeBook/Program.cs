using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var book = new Book("Gharib Grade Book");
            book.AddGrade(89.2);
            book.AddGrade(90.2);
            book.AddGrade(77.5);
            Console.WriteLine($"Book name is: {book.GetName()}");
            var result = book.GetStatistics();
            book.ShowStatistics(result);

        }
    }
}
