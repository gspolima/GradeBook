using System;
using Xunit;
using GradeBook;

namespace Gradebook.Tests
{
    public class BookTests
    {
        [Fact]
        public void CannotAddGradeOutOfRange()
        {
            var book = new Book();

            try
            {
                book.AddGrade(99);
                book.AddGrade(105);
            }
            catch (Exception)
            {     
                Console.WriteLine($"Value outside of bounds");
            }

            var expected = 1;
            var actual = book.GradesCount;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AssertAverageGrade()
        {
            // Arrange
            var book = new Book();
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
                var book = new Book("     ");
                Assert.Equal("default", book.Name);
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
                var book = new Book("");
                Assert.Equal("default", book.Name);
            }
            catch (ArgumentException)
            {
            }
        }

        [Fact]
        public void AssignCorrectLetterGrade()
        {
            var book = new Book();

            book.AddGrade(86);
            book.AddGrade(79.41);
            book.AddGrade(91);
            var stats = book.GetStatistics();
            
            Assert.Equal('B', stats.Letter);
        }
    }
}
