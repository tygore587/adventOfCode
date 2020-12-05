using Helper;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Number02
{
    class Number02
    {
        static void Main(string[] args)
        {
            var inputList = InputHelper.GetInputAsList("input.txt");

            var correctPasswords = inputList.Count(item =>
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

            Console.WriteLine(correctPasswords);
        }

        static bool TryExtractRule(string combinedRule, out int minOccur, out int maxOccur, out string letter)
        {
            minOccur = -1;
            maxOccur = -1;
            letter = null;

            var splitedRule = combinedRule.Split(" ");

            if (splitedRule.Length != 2)
                return false;

            letter = splitedRule[1].Trim();

            var occurences = splitedRule[0].Split("-");

            if (occurences.Length != 2)
                return false;

            minOccur = int.Parse(occurences[0]);
            maxOccur = int.Parse(occurences[1]);
            return true;
        }
        
        static bool ExtractRuleAndPassoword(string input, out string rule, out string password)
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
    }
}
