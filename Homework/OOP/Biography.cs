using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Homework.OOP
{
    internal record class Biography
    {
        public string _Name { get; init; }
        public string _Surname { get; init; }
        public int _Height { get; init; }
        public int _Age { get; init; }
        public Biography(string name, string surname, int height, int age)
        {
            _Name = name;
            _Surname = surname;
            _Height = height;
            _Age = age;
        }
    }

    public record struct BiographyChange
    {
        public int TownHall {  get; set; }
        public int BulliedСhildrenInRoblox { get; set; }

        public BiographyChange(int TownHall, int BulliedСhildrenInRoblox)
        {
            this.TownHall = TownHall;
            this.BulliedСhildrenInRoblox = BulliedСhildrenInRoblox;
        }
    }
}
