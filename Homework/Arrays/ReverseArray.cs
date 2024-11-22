using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Arrays
{
    internal class ReverseArray
    {
        public static void Reverse()
        {
            int[] array = { 1, 2, 3, 4, 5, 6 };
            int n, k;
            for (int i = 0; array.Length / 2 - 1 > i; i++)
            {
                n = array[^(i + 1)];
                k = array[i];
                array[i] = n;
                array[^(i + 1)] = k;
            }

            var str = string.Join(" ", array);
            Console.WriteLine(str);
        }
    }
}
