using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        int counter = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
        //Given
            WriteLogDelegate log = ReturnMessage;

            log += ReturnMessage;
            log += ReturnMessage2;
        //When
            var result = log("Hello");
        //Then
            Assert.Equal(3, counter);
            Assert.Equal("Hello", result);
        }

        string ReturnMessage(string message)
        {
            counter += 1;
            return message;
        }

        string ReturnMessage2(string message)
        {
            counter += 1;
            return message;
        }

        [Fact]
        public void StringBehaveLikeValueTypes()
        {
        //Given
            String name = "Ahmed";
            String upper = MakeUpperCase(name);
        //When
        
        //Then
            Assert.Equal("Ahmed", name);
            Assert.Equal("AHMED", upper);
        }

        private String MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
        //Given
            var x = GetInt();
            SetInt(ref x);
        //When
        
        //Then
            Assert.Equal(42, x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSHarpCanPassByRef()
        {
            // arrange
            var book1 = GetBook("Book 1");
            GetBookSetNameByRef(ref book1, "New Name");
            
            // act


            // assert
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetNameByRef(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSHarpIsPassByValue()
        {
            // arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            
            // act


            // assert
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // arrange
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            
            // act


            // assert
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            
            // act


            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;
            
            // act


            // assert
            Assert.True(Object.ReferenceEquals(book1, book2));
            Assert.Same(book1, book2);
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
