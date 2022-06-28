using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.ConnectedComponents
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static Queue<int> components;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            visited = new bool[n];


            for (int i = 0; i < n; i++)
            {
                graph[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            }

            for (int node = 0; node < graph.Length; node++)
            {
                if (!visited[node])
                {
                    continue;
                }

                components = new Queue<int>();
                DFS(node);

                Console.WriteLine($"Connected component: {string.Join(" ", components)}");
            }


        }

        private static void DFS(int node)
        {
            if (!visited[node])
            {
                visited[node] = true;
                foreach (var child in graph[node])
                {
                    DFS(child);
                }

                components.Enqueue(node);
            }
        }
    }
}
