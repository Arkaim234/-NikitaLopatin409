using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.String
{
    internal class Capitalization
    {
        public static void Capital() 
        {
            string s = "Слава россии!";
            var parts = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; parts.Length > i; i++)
            {
                var firstiiteral = parts[i].Substring(0, 1).ToUpper();
                parts[i] = firstiiteral + parts[i].Remove(0, 1);
            }
            string result = string.Join(" ", parts);
            Console.WriteLine(result);
        }
    }
}
