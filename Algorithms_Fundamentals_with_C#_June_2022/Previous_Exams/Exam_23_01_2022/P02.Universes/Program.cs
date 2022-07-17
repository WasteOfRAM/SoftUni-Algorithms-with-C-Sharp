using System;
using System.Collections.Generic;

namespace P02.Universes
{
    internal class Program
    {
        private static Dictionary<string, List<string>> planetarySystem;
        private static HashSet<string> visitedPlanets;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            planetarySystem = new Dictionary<string, List<string>>();
            visitedPlanets = new HashSet<string>();

            int systemsCount = 0;

            for (int i = 1; i <= n; i++)
            {
                var input = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);
                string planetOne = input[0].Trim();
                string planetTwo = input[1].Trim();

                if (!planetarySystem.ContainsKey(planetOne))
                    planetarySystem[planetOne] = new List<string>();

                planetarySystem[planetOne].Add(planetTwo);

                if (!planetarySystem.ContainsKey(planetTwo))
                    planetarySystem[planetTwo] = new List<string>();

                planetarySystem[planetTwo].Add(planetOne);
            }

            foreach (var planet in planetarySystem.Keys)
            {
                if (visitedPlanets.Contains(planet))
                {
                    continue;
                }

                systemsCount++;

                DFS(planet);
            }

            Console.WriteLine(systemsCount);
        }

        private static void DFS(string planet)
        {
            if (!visitedPlanets.Contains(planet))
            {
                visitedPlanets.Add(planet);

                foreach (var child in planetarySystem[planet])
                {
                    DFS(child);
                }
            }
        }
    }
}


//7
//Mercury - Mars
//Mars - Saturn
//Saturn - Venus
//Venus - Mars
//Dibiasky - Arion
//Arion - Mars
//Dimidium - Galileo


// output 2