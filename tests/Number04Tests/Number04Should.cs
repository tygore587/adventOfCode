using System.Collections.Generic;
using System.Linq;
using _Number04;
using Helper;
using Xunit;

namespace Number04Tests
{
    public class Number04Should
    {
        private static readonly IReadOnlyCollection<string> InputFromFile =
            InputHelper.GetInputAsList("inputTest.txt", Number04.FileSeparator).ToList();

        [Fact]
        public void ExtractPassportsCorrectlyFromFile()
        {
            var passports = Number04.ExtractPassportsFromList(InputFromFile).ToList();

            Assert.NotEmpty(passports);
            Assert.True(passports.Count == 4);
        }

        [Fact]
        public void GetCorrectNumberOfPassports()
        {
            var passports = Number04.ExtractPassportsFromList(InputFromFile);
            var validPassports = Number04.GetCountFromValidPassports(passports);

            Assert.True(validPassports == 2);
        }
    }
}