using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Helper;

namespace _Number04
{
    public class Number04
    {
        public static readonly string FileSeparator = Environment.NewLine + Environment.NewLine;

        public static void Main(string[] args)
        {
            var validPassports = SolvePart01("inputProd.txt");
            Console.WriteLine(validPassports);
        }

        private static int SolvePart01(string fileName)
        {
            var inputList = InputHelper.GetInputAsList(fileName, FileSeparator);

            var passports = ExtractPassportsFromList(inputList);

            return GetCountFromValidPassports(passports);
        }

        public static int GetCountFromValidPassports(IEnumerable<Passport> passports)
        {
            return passports.Count(passport => passport.IsValid());
        }

        public static IEnumerable<Passport> ExtractPassportsFromList(IEnumerable<string> inputs)
        {
            var passports = new ConcurrentBag<Passport>();

            Parallel.ForEach(inputs, passportString =>
            {
                if (string.IsNullOrWhiteSpace(passportString))
                    return;

                var fields = Regex.Split(passportString, "[\n\\s]");

                var fieldsDictionary = fields.Select(field => field.Split(":"))
                    .Where(keyValueList => keyValueList.Length == 2)
                    .ToDictionary(kvList => kvList[0],kvList => kvList[1]);
                
                passports.Add(Passport.FromDictionary(fieldsDictionary));
            });

            return passports;
        }
    }
}