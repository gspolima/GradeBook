using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {

        public override event GradeAddedDelegate GradeAdded;
        
        public override event StatisticsComputedDelegate StatisticsComputed;

        public override void AddGrade(double grade)
        {
            try
            {
                if (MatchGradePattern(grade))
                {
                    using (var writer = File.AppendText($"{base.Name}.txt"))
                    {
                        writer.WriteLine(grade);
                        if (GradeAdded != null)
                            GradeAdded(this, new EventArgs());
                    } // this 'using' syntax will, behind the scenes, perform a Dispose() call and free up resources
                }
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var grade = Double.Parse(line);
                    statistics.SetHighestGrade(grade);
                    statistics.SetLowestGrade(grade);
                    statistics.IncrementSum(grade);
                    statistics.IncrementGradesCount();
                    line = reader.ReadLine();
                }
                statistics.SetLetterGrade(statistics.Average);

                if (StatisticsComputed != null)
                    StatisticsComputed(this, new EventArgs());
            }
            
            return statistics;
        }
    }
}