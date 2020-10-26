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
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
        }
    }
}
