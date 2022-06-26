using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.School_Teams
{
    internal class Program
    {
        static void Main()
        {
            var girlsNames = Console.ReadLine().Split(", ");
            string[] girlsCombination = new string[3];

            var boysNames = Console.ReadLine().Split(", ");
            string[] boysCombination = new string[2];

            var girlsCombinations = new List<string[]>();
            var boysCombinations = new List<string[]>();


            Combinations(0, 0, girlsNames, girlsCombination, girlsCombinations);
            Combinations(0, 0, boysNames, boysCombination, boysCombinations);

            foreach (var girlCombination in girlsCombinations)
            {
                foreach (var boyCombination in boysCombinations)
                {
                    Console.WriteLine(string.Join(", ", girlCombination) + ", " + string.Join(", ", boyCombination));
                }
            }
        }

        private static void Combinations(int index, int start, string[] names, string[] combination, List<string[]> combinations)
        {
            if(index >= combination.Length)
            {
                combinations.Add(combination.ToArray());
                return;
            }

            for (int i = start; i < names.Length; i++)
            {
                combination[index] = names[i];
                Combinations(index + 1, i + 1, names, combination, combinations);
            }
        }
    }
}
