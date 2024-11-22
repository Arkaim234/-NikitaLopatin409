using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PrimitivTypes
{
    internal class BinuryNumery
    {
        public static void Binury() 
        {
            var n = Int32.Parse(Console.ReadLine());
            string resulte = "";
            while (n > 0)
            {
                resulte = (n % 2).ToString() + resulte;
                n = n / 2;
            }
            Console.WriteLine(resulte);
        }
    }
}
