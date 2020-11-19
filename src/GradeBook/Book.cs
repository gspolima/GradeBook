using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book()
        {
            grades = new List<double>();
        }
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public Book(string name, string category)
        {
            grades = new List<double>();
            Name = name;
            Category = category;
        }

        public char SetLetterGrade(double average)
        {
            char letter;
            switch (average)
            {
                case var avg when avg >= 90.0:
                    letter = 'A';
                    break;
                case var avg when avg >= 80.0:
                    letter = 'B';
                    break;
                case var avg when avg >= 70.0:
                    letter = 'C';
                    break;
                case var avg when avg >= 60.0:
                    letter = 'D';
                    break;
                default:
                    letter = 'F';
                    break;
            }
            return letter;
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);   
            }
            else
            {
                throw new ArgumentException($"Invalid value provided for {nameof(grade)}");
            }
        }

        public Statistics GetStatistics()
        {
            var results = new Statistics();

            for (int index = 0; index < grades.Count; index++)
            {
                results.Highest = Math.Max(results.Highest, grades[index]);
                results.Lowest = Math.Min(results.Lowest, grades[index]);
                results.Sum += grades[index];
            }
            results.Average = results.Sum / GradesCount;
            results.Letter = SetLetterGrade(results.Average);
            return results;
        }

        public void ShowStatistics(Statistics results)
        {
            Console.WriteLine($"The average is {results.Average:N2}");
            Console.WriteLine($"The highest grade is {results.Highest:N1}");
            Console.WriteLine($"The lowest grade is {results.Lowest:N1}");
            Console.WriteLine($"The letter grade is {results.Letter}");
        }

        public void ShowBookOwnership()
        {
            Console.WriteLine($"This book belongs to {this.Name}");
        }

        public int GradesCount { get => grades.Count; }
        protected List<double> grades;
        private string category;
        public string Category 
        { 
            get 
            {
                return category;
            }
            set
            {
                if (IsNullOrEmpty(value) || IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The category cannot be empty");
                }
                else if (CanConvertToDouble(value))
                {
                    throw new FormatException("The category cannot be a numeric value");
                }
                else
                {
                    category = value;
                }
            }
        }
        private string name;
        public string Name 
        {
            get
            {
                return name;
            }
            set
            {
                if (IsNullOrEmpty(value) || IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The book name cannot be empty");
                }
                else if(CanConvertToDouble(value))
                {
                    throw new FormatException("The book name cannot be a numeric value");
                }
                else
                {
                    name = value;
                }
            }
        }

        public bool IsNullOrEmpty(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsNullOrWhiteSpace(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
        public bool CanConvertToDouble(string value)
        {
            if (Double.TryParse(value, out double output))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}