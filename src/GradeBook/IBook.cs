using System;

namespace GradeBook
{
    interface IBook
    {
        void AddGrade(double grade);

        Statistics GetStatistics();

        string Name { get; set; }

        event GradeAddedDelegate GradeAdded;

        event StatisticsComputedDelegate StatisticsComputed;
    }
}

