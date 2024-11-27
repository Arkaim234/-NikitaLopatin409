using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.String
{
    internal class ExtractuNumber
    {
        public static void Extract()
        {
            string str = "1r234c56t7";
            string res = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    res = res + str[i];
                }
            }
            Console.WriteLine(res);
        }
    }
}
