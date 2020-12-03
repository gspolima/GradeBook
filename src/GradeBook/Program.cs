using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook();
            book.GradeAdded += OnGradeAdded;
            book.StatisticsComputed += OnStatisticsComputed;

            SetBookName(book);
            SetBookCategory(book);
            GetGradesByUserInput(book);

            var statistics = book.GetStatistics();
            book.ShowBookOwnership();
            book.ShowStatistics(statistics);
        }

        private static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("[+] Grade successfully added");
        }

        private static void OnStatisticsComputed(object sender, EventArgs args)
        {
            Console.WriteLine("[#] The book statistics have been computed");
        }

        private static void GetGradesByUserInput(IBook book)
        {
            for (var done = false; done == false;)
            {
                Console.WriteLine("-> Enter a grade or type 'Q' to quit and start the computation");
                try
                {
                    var input = Console.ReadLine();
                    if (input.ToUpper() == "Q")
                    {
                        Console.WriteLine("----------Finishing input----------");
                        done = true;
                    }
                    else
                    {
                        book.AddGrade(Double.Parse(input));
                    }
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
                catch (Exception generalException)
                {
                    Console.WriteLine($"A fatal error occurred {generalException.Source}");
                    throw;
                }
            }
        }

        private static void SetBookName(IBook book)
        {
            Console.WriteLine("Enter the book name:");
            for (var done = false; done == false;)
            {
                try
                {
                    book.Name = Console.ReadLine();
                    done = true;
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
            }
        }

        private static void SetBookCategory(IBook book)
        {
            Console.WriteLine("Enter the book category:");
            for (var done = false; done == false;)
            {
                try
                {
                    book.Category = Console.ReadLine();
                    done = true;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
            }
        }
    }
}