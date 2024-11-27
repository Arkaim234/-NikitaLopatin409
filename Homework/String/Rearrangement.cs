using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.String
{
    internal class Rearrangement
    {
        public static void Anagramma()
        {
            string s = "апельсин";
            string n = "спаниель";
            int result = 0;
            for (int i = 0; s.Length - 1 > i; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    if (s.Substring(i, 1) == n.Substring(j, 1))
                    {
                        result++;
                        break;
                        if (result == s.Length) Console.WriteLine("Это аннаграмма");
                    }
                }
            }
            Console.WriteLine("Точно не аннаграмма");
        }
    }
}
