using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04.Cinema
{
    internal class Program
    {
        private static List<string> nonStaticPeople;
        private static bool[] reservedSeats;
        private static string[] staticPeople;

        static void Main()
        {
            nonStaticPeople = Console.ReadLine().Split(", ").ToList();

            reservedSeats = new bool[nonStaticPeople.Count];
            staticPeople = new string[nonStaticPeople.Count];

            string command;
            while ((command = Console.ReadLine()) != "generate")
            {
                string name = command.Split(" - ")[0];
                int seat = int.Parse(command.Split(" - ")[1]) - 1;

                reservedSeats[seat] = true;
                staticPeople[seat] = name;

                nonStaticPeople.Remove(name);
            }

            SitingPremutations(0);
        }

        private static void SitingPremutations(int index)
        {
            if (index >= nonStaticPeople.Count)
            {
                Print();
                return;
            }

            SitingPremutations(index + 1);

            for (int i = index + 1; i < nonStaticPeople.Count; i++)
            {
                Swap(index, i);
                SitingPremutations(index + 1);
                Swap(index, i);

            }
        }

        private static void Print()
        {
            var sb = new StringBuilder();

            int index = 0;

            for (int i = 0; i < staticPeople.Length; i++)
            {
                if (reservedSeats[i])
                    sb.Append(staticPeople[i] + " ");
                else
                    sb.Append(nonStaticPeople[index++] + " ");
            }
            Console.WriteLine(sb.ToString().Trim());
        }

        private static void Swap(int first, int second)
        {
            var temp = nonStaticPeople[first];
            nonStaticPeople[first] = nonStaticPeople[second];
            nonStaticPeople[second] = temp;
        }
    }
}
