using System;

namespace GradeBook
{
    interface IBook
    {
        void AddGrade(double grade);

        Statistics GetStatistics();

        void ShowBookOwnership();

        void ShowStatistics(Statistics statistics);

        bool MatchGradePattern(double grade);

        string Name { get; set; }

        string Category { get; set; }

        event GradeAddedDelegate GradeAdded;

        event StatisticsComputedDelegate StatisticsComputed;
    }
}

