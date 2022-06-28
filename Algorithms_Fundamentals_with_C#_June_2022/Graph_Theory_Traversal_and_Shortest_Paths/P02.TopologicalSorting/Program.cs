using System;
using System.Collections.Generic;
using System.Linq;

//Source Removal Algorithm

namespace P02.Topological
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> predecessorCount;
        private static List<string> sorted;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            graph = ReadGraph(n);
            predecessorCount = GetPredecessors(graph);

            TopologicalSort();
            
            if(predecessorCount.Count > 0)
                Console.WriteLine("Invalid topological sorting");
            else
                Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
        }

        private static void TopologicalSort()
        {
            sorted = new List<string>();

            while (predecessorCount.Count > 0)
            {
                var node = predecessorCount.FirstOrDefault(n => n.Value == 0);

                if (node.Key == null)
                    break;

                foreach (var child in graph[node.Key])
                {
                    predecessorCount[child]--;
                }

                sorted.Add(node.Key);
                predecessorCount.Remove(node.Key);
            }
        }

        private static Dictionary<string, int> GetPredecessors(Dictionary<string, List<string>> graph)
        {
            var result = new Dictionary<string, int>();

            foreach (var (node, children) in graph)
            {
                if(!result.ContainsKey(node))
                    result[node] = 0;

                foreach (var child in children)
                {
                    if (!result.ContainsKey(child))
                        result[child] = 1;
                    else
                        result[child]++;
                }
            }

            return result;
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var result = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();

                if (parts.Length == 1)
                    result[parts[0]] = new List<string>();
                else
                    result[parts[0]] = parts[1].Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            return result;
        }
    }
}
