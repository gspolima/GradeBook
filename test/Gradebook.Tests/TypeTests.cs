using System;
using Xunit;
using GradeBook;

namespace Gradebook.Tests
{
    public delegate string WriteLoggingMessage(string message);

    public class TypeTests
    {
        int delegateCallsCounter = 0;

        [Fact]
        public void WriteLoggingDelegateCanPointToFunction()
        {
            WriteLoggingMessage log = WriteMessage;
            log += WriteMessage;
            log += LogMessage;

            var result = log("Hello Delegate");

            Assert.Equal(3, delegateCallsCounter);
        }

        public string WriteMessage(string message)
        {
            delegateCallsCounter++;
            return message;
        }

        public string LogMessage(string message)
        {
            delegateCallsCounter++;
            return message;
        }

        [Fact]
        public void StringsAreImmutable()
        {
            var name = "name";

            name = StringToUpperCase(name);

            Assert.Equal("NAME", name);
        }

        private string StringToUpperCase(string name)
        {
            return name.ToUpper();
        }

        [Fact]
        public void ValueTypesCanBePassedByReference()
        {
            var number = GetInt();

            SetInt(ref number, 24);
            
            var expected = 24;
            var actual = number;
            Assert.Equal(expected, actual);
        }

        private void SetInt(ref int number, int newValue)
        {
            number = 24;
        }

        private int GetInt()
        {
            return 5;
        }

        [Fact]
        public void CSharpCanBePassedByReference()
        {
            var book1 = GetBook("book 1");

            GetBookSetName(ref book1, "book 2");
            
            var expected = "book 2";
            var actual = book1.Name;
            Assert.Equal(expected, actual);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book();
            book.Name = name;
        }

        [Fact]
        public void CSharpIsPassedByValue()
        {
            var book1 = GetBook("book 1");
            
            GetBookSetName(book1, "book 2");

            var expected = "book 1";
            var actual = book1.Name;
            Assert.Equal(expected, actual);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book();
            book.Name = name;
        }

        [Fact]
        public void CanChangeNameFromReference()
        {
            var book1 = GetBook("book 1");

            SetName(book1, "book 2");
            
            var expected = "book 2";
            var actual = book1.Name;
            Assert.Equal(expected, actual);
        }
        
        public void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjectReferences()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            
            var expected1 = "Book 1";
            var expected2 = "Book 2";
            var actual1 = book1.Name;
            var actual2 = book2.Name;
            
            Assert.Equal(expected1, actual1);
            Assert.Equal(expected2, actual2);
            Assert.NotSame(expected1, expected2);
        }

        [Fact]
        public void TwoVariablesCanHoldTheSameRef()
        {
            var book1 = GetBook("Book 1");
            
            var book2 = book1;
            
            Assert.Same(book1, book2);
        }

        private Book GetBook(string name)
        {
            var book = new Book();
            book.Name = name;
            return book;
        }
    }
}
