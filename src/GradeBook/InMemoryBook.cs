#nullable enable
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
        
        public InMemoryBook(string name, string category) : base(name, category)
        {
            grades = new List<double>();
        }
        
        public override void AddGrade(double grade)
        {
            if (MatchGradePattern(grade))
            {
                grades.Add(grade);
                if (GradeAdded != null)
                    GradeAdded(this, new EventArgs());
            }
        }
        
        public override event GradeAddedDelegate? GradeAdded;
        
        public override event StatisticsComputedDelegate? StatisticsComputed;
        
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            for (int i = 0; i < grades.Count; i++)
            {
                statistics.SetHighestGrade(grades[i]);
                statistics.SetLowestGrade(grades[i]);
                statistics.IncrementSum(grades[i]);
                statistics.IncrementGradesCount();
            }
            statistics.SetLetterGrade(statistics.Average);

            if (StatisticsComputed != null)
                StatisticsComputed(this, new EventArgs());
            return statistics;
        }
        
        protected List<double> grades;
    }
}