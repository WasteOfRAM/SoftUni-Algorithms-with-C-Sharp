using System;
using System.Collections.Generic;
using System.Linq;

//DFS Topological Sorting

namespace P02.Topological
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;
        private static Stack<string> sorted;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);

            visited = new HashSet<string>();
            cycles = new HashSet<string>();
            sorted = new Stack<string>();

            bool isCyclic = false;

            foreach (var node in graph.Keys)
            {
                try
                {
                    TopSortDFS(node);
                }
                catch (InvalidOperationException)
                {
                    isCyclic = true;
                    break;
                }
            }

            if (isCyclic)
                Console.WriteLine("Invalid topological sorting");
            else
                Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
        }

        private static void TopSortDFS(string node)
        {
            if (cycles.Contains(node))
                throw new InvalidOperationException("Error");

            if (visited.Contains(node))
                return;

            cycles.Add(node);
            visited.Add(node);

            foreach (var child in graph[node])
            {
                TopSortDFS(child);
            }

            sorted.Push(node);
            cycles.Remove(node);
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var result = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();
                string key = parts[0];

                if (parts.Length == 1)
                {
                    result[key] = new List<string>();
                }
                else
                {
                    var children = parts[1].Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
                    result[key] = children;
                }
            }

            return result;
        }
    }
}
