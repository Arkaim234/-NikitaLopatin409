using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PrimitivTypes
{
    internal class LongestSubArray
    {
        public static void SubArray() 
        {
            var size = Int32.Parse(Console.ReadLine());
            int[] number = new int[size];
            for (int i = 0; i < number.Length; i++)
            {
                number[i] = Int32.Parse(Console.ReadLine());
            }
            var length = 0;
            int left_index = 0;
            int right_index = 0;
            while (right_index < number.Length)
            {
                if (number[left_index] == number[right_index])
                {
                    right_index++;
                }
                else
                {
                    length = Math.Max(length, right_index - left_index);
                    left_index = right_index;
                }
            }
            length = Math.Max(length, right_index - left_index);
            Console.WriteLine(length);
        }
    }
}
