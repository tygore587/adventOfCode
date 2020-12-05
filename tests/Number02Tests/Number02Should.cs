using _Number02;
using System.Collections.Generic;
using Xunit;

namespace Number02Tests
{
    public class Number02Should
    {
        [Fact]
        public void CountsCorrectlyByRule1Correctly()
        {
            var testLine = "1-3 a: aabba";
            var testRules = new List<string> { testLine };

            var expectedCount = 1;

            var actualCounts = Number02.CountCorrectPasswordByFirstRule(testRules);

            Assert.Equal(expectedCount, actualCounts);

            var testFailedLine = "4-6 a: aabba";
            var testFailedRules = new List<string> { testFailedLine };

            var expectedFailCount = 0;

            var actualFailCount = Number02.CountCorrectPasswordByFirstRule(testFailedRules);

            Assert.Equal(expectedFailCount, actualFailCount);
        }

        [Fact]
        public void CountsCorrectlyByRule2Correctly()
        {
            var testLine = "1-3 a: aabba";
            var testRules = new List<string> { testLine };

            var expectedCount = 1;

            var actualCounts = Number02.CountCorrectPasswordsBySecondRule(testRules);

            Assert.Equal(expectedCount, actualCounts);

            var testFailedLine = "1-3 a: ababa";
            var testFailedRules = new List<string> { testFailedLine };

            var expectedFailCount = 0;

            var actualFailCount = Number02.CountCorrectPasswordsBySecondRule(testFailedRules);

            Assert.Equal(expectedFailCount, actualFailCount);
        }

        [Fact]
        public void ExtractMinAndMaxOccurencesAndLetterCorrectly()
        {
            var testRule = "1-3 a";

            var expectedMinOccur = 1;
            var expectedMaxOccur = 3;
            var expectedLetter = "a";

            var actualSuccess = Number02.TryExtractRule(testRule, out var actualMinOccur, out var actualMaxOccur, out var actualLetter);

            Assert.True(actualSuccess);
            Assert.Equal(expectedMinOccur, actualMinOccur);
            Assert.Equal(expectedMaxOccur, actualMaxOccur);
            Assert.Equal(expectedLetter, actualLetter);
        }

        [Fact]
        public void SplitInputCorrectly()
        {
            var testRule = "1-3 a: test";

            var expectedRule = "1-3 a";
            var expectedPassword = "test";

            var actualSuccess = Number02.ExtractRuleAndPassoword(testRule, out var actualRule, out var actualPassword);

            Assert.True(actualSuccess);
            Assert.Equal(expectedRule, actualRule);
            Assert.Equal(expectedPassword, actualPassword);
        }
    }
}