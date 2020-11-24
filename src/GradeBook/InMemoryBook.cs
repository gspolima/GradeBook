using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        public InMemoryBook() : base()
        {
            grades = new List<double>();
        }

        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
        }
        
        public InMemoryBook(string name, string category) : base(name)
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
        
        public override void AddGrade(double grade)
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
        
        public override event GradeAddedDelegate GradeAdded;
        
        public override event StatisticsComputedDelegate StatisticsComputed;
        
        public override Statistics GetStatistics()
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
        
        public override int GradesCount { get => grades.Count; }
        
        protected List<double> grades;
    }
}