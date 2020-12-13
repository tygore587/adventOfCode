using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Helper
{
    public static class InputHelper
    {
        public static IEnumerable<string> GetInputAsList(string fileName, string separator = "\n")
        {
            return GetInputAsListAsync(fileName, separator).GetAwaiter().GetResult();
        }

        public static async Task<IEnumerable<string>> GetInputAsListAsync(string fileName, string separator = "\n")
        {
            var input = await File.ReadAllTextAsync(fileName);
            return input.Split(separator);
        }
    }
}