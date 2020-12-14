using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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

        public bool IsValidPart01()
        {
            return !string.IsNullOrWhiteSpace(BirthYear)
                   && !string.IsNullOrWhiteSpace(IssueYear)
                   && !string.IsNullOrWhiteSpace(ExpirationYear)
                   && !string.IsNullOrWhiteSpace(Height)
                   && !string.IsNullOrWhiteSpace(HairColor)
                   && !string.IsNullOrWhiteSpace(EyeColor)
                   && !string.IsNullOrWhiteSpace(PassportId);
        }

        public bool IsValidPart02()
        {
            return IsBirthYearValid()
                   && IsIssueYearValid()
                   && IsExpirationYearValid()
                   && IsHeightValid()
                   && IsHairColorValid()
                   && IsEyeColorValid()
                   && IsPassPortIdValid();
        }

        private bool IsBirthYearValid() =>
            BirthYear.IsDigitWithLength(4, out var birthYear) && birthYear.IsBetween(1920, 2002);

        private bool IsIssueYearValid() =>
            IssueYear.IsDigitWithLength(4, out var issueYear) && issueYear.IsBetween(2010, 2020);

        private bool IsExpirationYearValid() =>
            ExpirationYear.IsDigitWithLength(4, out var expirationYear)
            && expirationYear.IsBetween(2020, 2030);

        private bool IsHeightValid()
        {
            if (string.IsNullOrWhiteSpace(Height))
                return false;

            return Height[^2..] switch
            {
                "cm" => Height.Length == 5 && Height[..3].IsDigitWithLength(3, out var heightValue) &&
                        heightValue.IsBetween(150, 193),
                "in" => Height.Length == 4 && Height[..2].IsDigitWithLength(2, out var heightValue) &&
                        heightValue.IsBetween(59, 76),
                _ => false,
            };
        }

        private bool IsHairColorValid() => HairColor.IsColorString();

        private bool IsEyeColorValid() => EyeColor.IsOneOf("amb", "blu", "brn", "grn", "hzl", "oth");

        private bool IsPassPortIdValid() => PassportId.IsDigitWithLength(9, out _);

        public static Passport FromDictionary(IDictionary<string, string> inputDict)
        {
            var passportType = typeof(Passport);
            var result = new Passport();

            foreach (var (propertyName, propertyValue) in inputDict)
            {
                var translatedName = TranslateToPropertyName(propertyName);

                passportType.GetProperty(translatedName)?.SetValue(result, propertyValue, null);
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