using System;
using System.Collections.Generic;

namespace _Number04
{
    public class Passport
    {
        // byr
        public string BirthYear { get; set; }
        
        // iyr
        public string IssueYear { get; set; }

        // eyr
        public string ExpirationYear { get; set; }
        
        // hgt
        public string Height { get; set; }

        // hcl
        public string HairColor { get; set; }

        // ecl
        public string EyeColor { get; set; }

        // pid
        public string PassportId { get; set; }

        // cid
        public string CountryId { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(BirthYear)
                   && !string.IsNullOrWhiteSpace(IssueYear)
                   && !string.IsNullOrWhiteSpace(ExpirationYear)
                   && !string.IsNullOrWhiteSpace(Height)
                   && !string.IsNullOrWhiteSpace(HairColor)
                   && !string.IsNullOrWhiteSpace(EyeColor)
                   && !string.IsNullOrWhiteSpace(PassportId);
        }

        public static Passport FromDictionary(IDictionary<string, string> inputDict)
        {
            var passportType = typeof(Passport);
            var result = new Passport();

            foreach (var (propertyName, propertyValue) in inputDict)
            {
                var translatedName = TranslateToPropertyName(propertyName);
                
                passportType.GetProperty(translatedName)?.SetValue(result,propertyValue,null);
            }

            return result;
        }

        private static string TranslateToPropertyName(string fieldName)
        {
            return fieldName switch
            {
                "byr" => nameof(BirthYear),
                "iyr" => nameof(IssueYear),
                "eyr" => nameof(ExpirationYear),
                "hgt" => nameof(Height),
                "hcl" => nameof(HairColor),
                "ecl" => nameof(EyeColor),
                "pid" => nameof(PassportId),
                "cid" => nameof(CountryId),
                _ => null,
            };
        }
    }
}