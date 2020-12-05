using _Number02;
using System;
using Xunit;

namespace Number02Tests
{
    public class Number02Should
    {
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
    }
}
