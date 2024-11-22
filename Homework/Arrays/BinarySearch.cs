using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Arrays
{
    internal class BinarySearch
    {
        public static void Search() 
        {
            var find = false;

            int[] array = { 2, 3, 4, 5, 6, 7 };
            int number = int.Parse(Console.ReadLine());
            var midindex = array.Length / 2;
            var step = 0;
            string result = "";
            while (find == false)
            {
                if (number < array[^1])
                {
                    if (number < array[midindex])
                    {
                        midindex /= 2;
                    }
                    else if (number > array[midindex]) midindex = midindex + midindex / 2;
                    else
                    {
                        find = true;
                        result = midindex.ToString();
                    }
                    if (step == array.Length)
                    {
                        result = "Число отсутствует в масиве";
                        break;
                    }
                    step++;
                }
                else
                {
                    result = "Число отсутствует в масиве";
                    break;
                }
            }
            Console.WriteLine(result);
        }
    }
}
