using System;
using Xunit;

namespace GradeBook.Tests
{
    // public class UnitTest1
    // {
    //     [Fact]
    //     public void Test1()
    //     {
    //         // arrange - put together test data
    //         var x = 5;
    //         var y = 2;
    //         var expected = 7;

    //         // act - perform calculation
    //         var actual = x + y;

    //         // assert section
    //         Assert.Equal(expected, actual);
    //     }
    // }
    
    public class BookTest
    {
        [Fact]
        public void Test1()
        {
            // arrange
            var book = new Book("");
            book.Add(89.1);
            book.Add(90.5);
            book.Add(77.3);

            //act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average);
            Assert.Equal(90.5, result.High);
            Assert.Equal(77.3, result.Low);
        }
    }
}
