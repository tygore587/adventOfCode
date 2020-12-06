using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Number03
{
    internal class Number03
    {
        public static int CountSymbolsInWay(IEnumerable<string> inputs, string symbol, bool outputDebug = false)
        {
            var inputList = inputs.Select(i => i.Trim()).ToList();

            var currentRow = 0;
            var currentColoumn = 0;
            var treeHits = 0;

            while (currentRow < inputList.Count)
            {
                var currentRowString = inputList[currentRow];

                var currentSymbol = currentRowString[currentColoumn];

                var treeHit = string.Equals(currentSymbol.ToString(), symbol);

                if (outputDebug)
                {
                    var currentRowBuilder = new StringBuilder(currentRowString);
                    currentRowBuilder[currentColoumn] = treeHit ? 'X' : 'O';

                    Console.WriteLine(currentRowBuilder.ToString());
                }

                if (treeHit)
                    treeHits++;

                currentRow++;
                var potentionalNextColoumn = currentColoumn + 3;

                var rowLength = currentRowString.Length;

                currentColoumn = potentionalNextColoumn > rowLength - 1 ? potentionalNextColoumn - rowLength : potentionalNextColoumn;
            }

            return treeHits;
        }

        private static void Main(string[] args)
        {
            const string treeSymbol = "#";

            var inputList = InputHelper.GetInputAsList("input.txt");

            var treeHits = CountSymbolsInWay(inputList, treeSymbol);

            Console.WriteLine(treeHits);
        }
    }
}