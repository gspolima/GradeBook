using System;

namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        public Book() : base()
        {
        }

        public Book(string name) : base(name)
        {
        }

        public virtual event GradeAddedDelegate GradeAdded;

        public virtual event StatisticsComputedDelegate StatisticsComputed;

        public abstract void AddGrade(double grade);

        public virtual Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }
}