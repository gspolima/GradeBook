using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics
    {
        public Statistics()
        {
            Highest = double.MinValue;
            Lowest = double.MaxValue;
        }

        public void SetLetterGrade(double average)
        {
            switch (average)
            {
                case var avg when avg >= 90.0 :
                    Letter = 'A';
                    break;
                case var avg when avg >= 80.0 :
                    Letter = 'B';
                    break;
                case var avg when avg >= 70.0 :
                    Letter = 'C';
                    break;
                case var avg when avg >= 60.0 :
                    Letter = 'D';
                    break;
                default:
                    Letter = 'F';
                    break;
            }
        }

        public void SetHighestGrade(double value)
        {
            Highest = Math.Max(Highest, value);
        }

        public void SetLowestGrade(double value)
        {
            Lowest = Math.Min(Lowest, value);
        }

        public void IncrementSum(double value)
        {
            Sum += value;
        }

        public void IncrementGradesCount()
        {
            Count += 1;
        }
        
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public double Highest { get; private set; }

        public double Lowest { get; private set; }

        public double Sum { get; private set; } 

        public char Letter { get; private set; }

        public int Count { get; private set; }
    }
}