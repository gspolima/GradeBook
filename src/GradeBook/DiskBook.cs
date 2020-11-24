using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public override int GradesCount => throw new NotImplementedException();

        public override event GradeAddedDelegate GradeAdded;
        
        public override event StatisticsComputedDelegate StatisticsComputed;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{base.Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            } // this 'using' syntax will, behind the scenes, perform a Dispose() call and free up resources
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }
}