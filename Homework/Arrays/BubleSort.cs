using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Arrays
{
    internal class BubleSort
    {
        public static void Sort() 
        {
            int[] array = { 4, 5, 3, 1, 2, 6 };
            int s, n;
            var switche = 1;
            while (switche != 0)
            {
                switche = 0;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        s = array[i + 1];
                        n = array[i];
                        array[i] = s;
                        array[i + 1] = n;
                        switche++;
                    }
                }
            }
            var str = string.Join(" ", array);
            Console.WriteLine(str);
        }
    }
}
