using System.Collections.Generic;
using Xunit;

namespace _Number01
{
    public class Number01Should
    {
        [Fact]
        public void FindThreeNumbersCorrectly()
        {
            var inputList = new int[] { 3, 1, 2, 7 };

            var expectedNumbers = new List<int> { 1, 3, 7 };

            const int searchedNumber = 11;

            var (actualNumber1, actualNumber2, actualNumber3) = Number01.FindSumWith3(inputList, searchedNumber);

            Assert.Contains(actualNumber1, expectedNumbers);
            Assert.Contains(actualNumber2, expectedNumbers);
            Assert.Contains(actualNumber3, expectedNumbers);
        }

        [Fact]
        public void FindTwoNumbersCorrectly()
        {
            var inputList = new int[] { 3, 1, 2, -1 };

            var expectedNumbers = new List<int> { 1, 3 };

            var searchedNumber = 4;

            var (actualLeft, actualRight) = Number01.FindSumWith2(inputList, searchedNumber);

            Assert.Contains(actualLeft, expectedNumbers);
            Assert.Contains(actualRight, expectedNumbers);
        }
    }
}