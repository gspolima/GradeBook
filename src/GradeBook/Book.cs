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
            if (MatchGradePattern(grade))
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }
        public event GradeAddedDelegate GradeAdded;
        public event StatisticsComputedDelegate StatisticsComputed;
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

            if (StatisticsComputed != null)
            {
                StatisticsComputed(this, new EventArgs());
            }
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
        public bool MatchStringPattern(string value)
        {
            if (IsNullOrEmpty(value) || IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"Empty values are not valid for this field");
            }
            else if(CanConvertToDouble(value))
            {
                throw new FormatException($"Numeric values are not valid for this field");
            }
            else
            {
                return true;
            }
        }    
        public bool MatchGradePattern(double grade)
        {
            if (grade < 0 || grade > 100)
            {
                throw new ArgumentException($"Invalid value provided for {nameof(grade)}");
            }
            else
            {
                return true;
            }
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
                if (MatchStringPattern(value))
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
                if(MatchStringPattern(value))
                {
                    name = value;
                }
            }
        }
    }
}