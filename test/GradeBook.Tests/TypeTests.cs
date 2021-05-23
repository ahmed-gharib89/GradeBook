using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
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

        private void GetBookSetNameByRef(ref Book book, string name)
        {
            book = new Book(name);
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

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
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

        private void SetName(Book book, string name)
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
            Assert.Equal("Book 1", book1.GetName());
            Assert.Equal("Book 2", book2.GetName());
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

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
