using System;
#nullable enable

namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        public Book() : base()
        {
            category = "no category";
        }

        public Book(string name) : base(name)
        {
            category = "no category";
        }
        public Book(string name, string category) : base(name)
        {
            this.category = category;
        }

        private string category;

        public virtual string Category
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

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract event StatisticsComputedDelegate StatisticsComputed;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();

        public virtual bool MatchGradePattern(double grade)
        {
            if (grade < 0 || grade > 100)
            {
                throw new ArgumentException($"[!] {grade} is not a valid value for {nameof(grade)}");
            }
            else
            {
                return true;
            }
        }

        public virtual void ShowBookOwnership()
        {
            Console.WriteLine($"This book belongs to {base.Name}");
        }

        public virtual void ShowStatistics(Statistics statistics)
        {
            Console.WriteLine($"The average is {statistics.Average:N2}");
            Console.WriteLine($"The highest grade is {statistics.Highest:N1}");
            Console.WriteLine($"The lowest grade is {statistics.Lowest:N1}");
            Console.WriteLine($"The letter grade is {statistics.Letter}");
        }
    }
}