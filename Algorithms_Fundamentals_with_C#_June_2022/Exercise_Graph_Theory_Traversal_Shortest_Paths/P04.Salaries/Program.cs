using System;
using System.Collections.Generic;

namespace P04.Salaries
{
    internal class Program
    {
        private static List<int>[] graph;
        private static Dictionary<int, int> salarySheet;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            salarySheet = new Dictionary<int, int>();

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'Y')
                        graph[i].Add(j);
                }
            }

            int totalSalary = 0;

            for (int index = 0; index < graph.Length; index++)
            {
                totalSalary += DFS(index);
            }

            Console.WriteLine(totalSalary);
        }

        private static int DFS(int node)
        {
            if (salarySheet.ContainsKey(node))
                return salarySheet[node];

            if (graph[node].Count == 0)
            {
                salarySheet[node] = 1;
                return salarySheet[node];
            }

            salarySheet[node] = 0;
            foreach (var child in graph[node])
            {
                salarySheet[node] += DFS(child);
            }

            return salarySheet[node];
        }
    }
}
