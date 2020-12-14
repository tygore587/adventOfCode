using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
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
            var passports = GetPassports("inputProd.txt").ToList();
            var validPassportsPart01 = GetCountFromValidPassportsPart01(passports);
            var validPassportsPart02 = GetCountFromValidPassportsPart02(passports);
            
            
            Console.WriteLine($"Valid Passports Part01: {validPassportsPart01} | Valid Passports Part02: {validPassportsPart02}");
        }
        
        private static IEnumerable<Passport> GetPassports(string fileName)
        {
            var inputList = InputHelper.GetInputAsList(fileName, FileSeparator);

            return ExtractPassportsFromList(inputList);
        }

        public static int GetCountFromValidPassportsPart01(IEnumerable<Passport> passports) =>
            passports.Count(passport => passport.IsValidPart01());

        public static int GetCountFromValidPassportsPart02(IEnumerable<Passport> passports) =>
            passports.Count(passport => passport.IsValidPart02());

        public static IEnumerable<Passport> ExtractPassportsFromList(IEnumerable<string> inputs)
        {
            var passports = new ConcurrentBag<Passport>();

            Parallel.ForEach(inputs, passportString =>
            {
                if (string.IsNullOrWhiteSpace(passportString))
                    return;

                var fields = Regex.Split(passportString, "[\n\\s]");

                var fieldsDictionary = fields
                    .Select(field => field.Split(":"))
                    .Where(keyValueList => keyValueList.Length == 2)
                    .ToDictionary(kvList => kvList[0],kvList => kvList[1]);
                
                passports.Add(Passport.FromDictionary(fieldsDictionary));
            });

            return passports;
        }
    }
}