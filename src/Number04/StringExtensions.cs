using System.Globalization;
using System.Linq;

namespace _Number04
{
    public static class StringExtensions
    {
        public static bool IsDigit(this string input, out int valueAsInt)
        {
            valueAsInt = 0;
            return !string.IsNullOrWhiteSpace(input) && int.TryParse(input, out valueAsInt);  
        } 

        public static bool IsBetween(this int number, int min, int max) => number >= min && number <= max;

        public static bool IsColorString(this string input)
        {
            var colorHex = input?.Replace("#", "");
            return input?.StartsWith("#") == true && colorHex.Length == 6
                   && int.TryParse(colorHex, NumberStyles.HexNumber, null, out _);
        }

        public static bool IsOneOf(this string input, params string[] possibleValues) => possibleValues.Contains(input);

        public static bool IsDigitWithLength(this string input, int length, out int valueAsInt)
        {
            valueAsInt = 0;
            return !string.IsNullOrWhiteSpace(input) && IsDigit(input, out valueAsInt) && input.Length == length;
        }
    }
}