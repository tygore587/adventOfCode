using Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _Number02
{
    public class Number02
    {
        public static int CountCorrectPasswordByFirstRule(IEnumerable<string> inputList)
        {
            return inputList.Count(item =>
            {
                var success = ExtractRuleAndPassoword(item, out var rule, out var password);

                if (!success)
                    return false;

                if (TryExtractRule(rule, out var minOccur, out var maxOccur, out string letter))
                {
                    var occurLetter = password.Count(c => string.Equals(c.ToString(), letter));

                    return occurLetter >= minOccur && occurLetter <= maxOccur;
                }

                return false;
            });
        }

        public static int CountCorrectPasswordsBySecondRule(IEnumerable<string> inputList)
        {
            return inputList.Count(item =>
            {
                var success = ExtractRuleAndPassoword(item, out var rule, out var password);

                if (!success)
                    return false;

                if (TryExtractRule(rule, out var firstPosition, out var secondPosition, out string letter))
                {
                    if (firstPosition <= 0 || firstPosition >= secondPosition || secondPosition <= 0 || password.Length < secondPosition)
                        return false;

                    return string.Equals(password[firstPosition - 1].ToString(), letter) ^ string.Equals(password[secondPosition - 1].ToString(), letter);
                }

                return false;
            });
        }

        public static bool ExtractRuleAndPassoword(string input, out string rule, out string password)
        {
            rule = null;
            password = null;

            var rulePasswordSplit = input.Split(":");

            if (rulePasswordSplit.Length != 2)
                return false;

            rule = rulePasswordSplit[0];
            password = rulePasswordSplit[1].Trim();

            return true;
        }

        public static bool TryExtractRule(string combinedRule, out int firstNumber, out int secondNumber, out string letter)
        {
            firstNumber = -1;
            secondNumber = -1;
            letter = null;

            var splitedRule = combinedRule.Split(" ");

            if (splitedRule.Length != 2)
                return false;

            letter = splitedRule[1].Trim();

            var occurences = splitedRule[0].Split("-");

            if (occurences.Length != 2)
                return false;

            firstNumber = int.Parse(occurences[0]);
            secondNumber = int.Parse(occurences[1]);
            return true;
        }
        private static void Main(string[] args)
        {
            var inputList = InputHelper.GetInputAsList("input.txt");

            var correctPasswordsRule1 = CountCorrectPasswordByFirstRule(inputList);

            var correctPasswordsRule2 = CountCorrectPasswordsBySecondRule(inputList);

            Console.WriteLine($"Correct Passwords Rule 1: {correctPasswordsRule1} | Correct Passwords Rule 2: {correctPasswordsRule2}");
        }
    }
}