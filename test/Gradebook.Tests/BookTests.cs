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
            var listOfGrades = new List<double>() { 81, 99, -2, 105, 156215614561};
            
            for (int index = 0; index < listOfGrades.Count; index++)
            {
                try
                {
                    book.AddGrade(listOfGrades[index]);
                }
                catch (ArgumentException)
                {
                }
            }
            Assert.Equal(2, book.GradesCount);
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
    }
}
