using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.String
{
    internal class Changeling
    {
        public static void Palindrom()
        {
            string text = "Аргентина манит негра";
            var s = text.Replace(" ", string.Empty);
            s = s.ToLower();
            int lastIndex = s.Length - 1;
            for (int i = 0; s.Length / 2 > i; i++)
            {
                if (s[i] != s[lastIndex - i])
                {
                    Console.WriteLine("Не является палиндромом");
                }
            }
            Console.WriteLine("Является палиндромом");
        }
    }
}
