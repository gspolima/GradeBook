using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book();
            SetBookName(book);
            SetBookCategory(book);
            GetGradesByUserInput(book);
            var statistics = book.GetStatistics();
            book.ShowBookOwnership();
            book.ShowStatistics(statistics);
        }
        
        static void GetGradesByUserInput(Book book)
        {
            for (var done = false; done == false;)
            {
                Console.WriteLine("Enter a grade or type 'Q' to quit and start the computation");
                try
                {
                    var input = Console.ReadLine();
                    if (input.ToUpper() == "Q")
                    {
                        Console.WriteLine("Finishing input...");
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
                    Console.WriteLine($"A fatal error occurred. Application halted. {generalException.Source}");
                    throw;
                }
                finally
                {
                    Console.Write("==> ");
                }
            }
        }

        static void SetBookName(Book book)
        {
            Console.WriteLine("Enter the book name");
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

        static void SetBookCategory(Book book)
        {
            Console.WriteLine("Enter the book category");
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