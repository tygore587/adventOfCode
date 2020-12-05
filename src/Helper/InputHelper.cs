using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Helper
{
    public static class InputHelper
    {
        public static async Task<IEnumerable<string>> GetInputAsListAsync(string fileName)
        {
            var input = await File.ReadAllTextAsync("input.txt");
            return input.Split("\n");
        }

        public static IEnumerable<string> GetInputAsList(string fileName)
        {
            return GetInputAsListAsync(fileName).GetAwaiter().GetResult();
        }
    }
}
