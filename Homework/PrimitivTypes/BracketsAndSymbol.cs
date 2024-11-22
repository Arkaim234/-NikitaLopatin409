﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PrimitivTypes
{
    internal class BracketsAndSymbol
    {
        public static void Brackets() 
        {
            Console.WriteLine("Количество значений в массиве?");
            var size = Int32.Parse(Console.ReadLine());
            string[] elements = new string[size];
            Console.WriteLine("Скобки, которые надо добавить в массив?");
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = Console.ReadLine();
            }
            int count = 0;
            int maxCount = -1000;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] == "(") count++;
                else count--;
                maxCount = Math.Max(maxCount, count);
            }
            if (count == 0) Console.WriteLine("true " + maxCount);
            else Console.WriteLine("false " + maxCount);

        }
    }
}