using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _Number01
{
    public class Number01
    {
        public static (int left, int right) FindSumWith2(IEnumerable<int> inputList, int searchedValue)
        {
            var right = 0;
            var left = inputList.FirstOrDefault(number1 =>
            {
                right = inputList.FirstOrDefault(number2 => number1 + number2 == searchedValue);
                return right > 0;
            });

            return (left, right);
        }

        public static (int number1, int number2, int number3) FindSumWith3(IEnumerable<int> inputList, int searchedValue)
        {
            var result2 = 0;
            var result3 = 0;
            var result1 = inputList.FirstOrDefault((number1) =>
            {
                (result2, result3) = FindSumWith2(inputList, searchedValue - number1);

                return result2 > 0 && result3 > 0;
            });

            return (result1, result2, result3);
        }

        private static (int left, int right) FindSum2020With2(IEnumerable<int> inputList)
        {
            return FindSumWith2(inputList, 2020);
        }

        private static (int number1, int number2, int number3) FindSum2020With3(IEnumerable<int> inputList)
        {
            return FindSumWith3(inputList, 2020);
        }

        private static async Task Main(string[] args)
        {
            var inputList = await InputHelper.GetInputAsListAsync("input.txt");

            var inputListAsInt = inputList.Select(item => int.TryParse(item, out var itemInt) ? itemInt : 0);

            var (left, right) = FindSum2020With2(inputListAsInt);

            Console.WriteLine($"Part 1: {left * right}");

            var (number1, number2, number3) = FindSum2020With3(inputListAsInt);

            Console.WriteLine($"Part 2: {number1 * number2 * number3}");
        }
    }
}