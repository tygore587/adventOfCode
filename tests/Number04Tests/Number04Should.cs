using System.Collections.Generic;
using System.Linq;
using _Number04;
using Helper;
using Xunit;

namespace Number04Tests
{
    public class Number04Should
    {
        private static readonly IReadOnlyCollection<string> InputFromFilePart01 =
            InputHelper.GetInputAsList("inputTest.txt", Number04.FileSeparator).ToList();
        
        private static readonly IReadOnlyCollection<string> InputFromFilePart02 =
            InputHelper.GetInputAsList("inputTestPart2.txt", Number04.FileSeparator).ToList();

        [Fact]
        public void ExtractPassportsCorrectlyFromFile()
        {
            var passports = Number04.ExtractPassportsFromList(InputFromFilePart01).ToList();

            Assert.NotEmpty(passports);
            Assert.True(passports.Count == 4);
        }

        [Fact]
        public void GetCorrectNumberOfPassportsPart01()
        {
            var passports = Number04.ExtractPassportsFromList(InputFromFilePart01);
            var validPassports = Number04.GetCountFromValidPassportsPart01(passports);

            Assert.True(validPassports == 2);
        }
        
        [Fact]
        public void GetCorrectNumberOfPassportsPart02()
        {
            var passports = Number04.ExtractPassportsFromList(InputFromFilePart02);
            var validPassports = Number04.GetCountFromValidPassportsPart02(passports);

            Assert.True(validPassports == 4);
        }
    }
}