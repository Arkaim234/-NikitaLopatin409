using Homework.OOP;

namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Biography Nikita = new Biography("Никита", "Лопатин", 191, 18);
            BiographyChange NikitaChange = new BiographyChange(13, 3);
            Console.WriteLine($"Name: {Nikita._Name}," + 
                $"Surname: {Nikita._Surname}, " +
                $"Height: {Nikita._Height}, " +
                $"Age: {Nikita._Age}");

            Console.WriteLine($"TawnHall: {NikitaChange.TownHall}," +
                $"BulliedСhildrenInRoblox: {NikitaChange.BulliedСhildrenInRoblox}");
        }
    }
}
