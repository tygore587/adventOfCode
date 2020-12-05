using System.Collections.Generic;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace _01
{
    class Number1
    {
        static async Task Main(string[] args)
        {
            var input = await File.ReadAllTextAsync("input.txt");
            var inputList = input.Split("\n").Select(item => int.TryParse(item, out var itemInInt) ? itemInInt : 0);

            var (left, right) = FindSum2020With2(inputList);

            Console.WriteLine($"Part 1: {left * right}");

            var (number1, number2, number3) = FindSum2020With3(inputList);

            Console.WriteLine($"Part 2: {number1 * number2 * number3}");
        }

        static (int left, int right) FindSum2020With2(IEnumerable<int> inputList)
        {
            var right = 0;
            var left = inputList.FirstOrDefault(number1 =>
            {
                right = inputList.FirstOrDefault(number2 => number1 + number2 == 2020);
                return right > 0;
            });

            return (left, right);
        }

        static (int number1, int number2, int number3) FindSum2020With3(IEnumerable<int> inputList)
        {
            var result2 = 0;
            var result3 = 0;
            var result1 = inputList.FirstOrDefault((number1) =>
            {
                result2 = inputList.FirstOrDefault((number2) =>
                {
                    result3 = inputList.FirstOrDefault(number3 => number1 + number2 + number3 == 2020);
                    return result3 > 0;
                });

                return result2 > 0;
            });

            return (result1, result2, result3);
        }
    }
}
