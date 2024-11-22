using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PrimitivTypes
{
    internal class Reverse
    {
        public static void Reversed()
        {
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine((n % 10) * 10 + n / 10);
        }
    }
}
