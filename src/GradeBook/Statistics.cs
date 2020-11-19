using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics
    {
        public Statistics()
        {
            Average = 0;
            Highest = double.MinValue;
            Lowest = double.MaxValue;
        }

        public double Average;

        public double Highest;

        public double Lowest;

        public double Sum;

        public char Letter;
    }
}