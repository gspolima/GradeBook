using System;
using Xunit;
using GradeBook;
using System.Collections.Generic;

namespace Gradebook.Tests
{
    public class BookTests
    {
        [Fact]
        public void AddGradeOnlyWithinBoundaries()
        {
            var book = new InMemoryBook();
            
            var listOfGrades = new List<double>() { 81, 99, -2};
            
            for (int i = 0; i < listOfGrades.Count; i++)
            {
                try
                {
                    book.AddGrade(listOfGrades[i]);
                }
                catch (ArgumentException)
                {
                }
            }
            var stats = book.GetStatistics();

            Assert.Equal(2, stats.Count);
        }

        [Fact]
        public void AssertAverageGrade()
        {
            // Arrange
            var book = new InMemoryBook();
            // Act
            book.AddGrade(50);
            book.AddGrade(90);
            book.AddGrade(70);
            var stats = book.GetStatistics();
            // Assert
            var expected = 70;
            var actual = stats.Average;
            Assert.Equal(expected, actual, 2);
        }

        [Fact]
        public void BookNameIsNotWhitespace()
        {
            try
            {
                var book = new InMemoryBook("     ");
                Assert.Equal(null, book.Name);
            }
            catch (ArgumentException)
            {
            }
        }

        [Fact]
        public void BookNameIsNotEmpty()
        {
            try
            {
                var book = new InMemoryBook("");
                Assert.Equal(null, book.Name);
            }
            catch (ArgumentException)
            {
            }
        }

        [Fact]
        public void AssignCorrectLetterGrade()
        {
            var book = new InMemoryBook();

            book.AddGrade(86);
            book.AddGrade(79.41);
            book.AddGrade(91);
            var stats = book.GetStatistics();

            Assert.Equal('B', stats.Letter);
        }

        [Fact]
        public void ComputeCorrectLowestGrade()
        {
            var book = new InMemoryBook();

            book.AddGrade(91);
            book.AddGrade(93);
            book.AddGrade(87);
            var stats = book.GetStatistics();

            Assert.Equal(87, stats.Lowest);
        }

        [Fact]
        public void IncrementGradesCounter()
        {
            var book = new InMemoryBook();

            book.AddGrade(85);
            book.AddGrade(87);
            book.AddGrade(71);
            book.AddGrade(99);
            var stats = book.GetStatistics();

            Assert.Equal(4, stats.Count);
        }
    }
}
