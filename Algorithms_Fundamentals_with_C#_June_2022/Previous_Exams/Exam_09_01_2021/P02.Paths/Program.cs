using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Paths
{
    public class Program
    {
        private static List<int>[] graph;
        private static HashSet<int> path;

        static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());

            graph = new List<int>[nodesCount];
            path = new HashSet<int>();

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            for(int i = 0; i < graph.Length - 1; i++)
            {
                var chilren = Console.ReadLine().Split().Select(int.Parse).ToArray();

                graph[i].AddRange(chilren);
            }

            for (int node = 0; node < graph.Length; node++)
            {
                if (graph[node].Count == 0)
                    continue;

                DFS(node);
            }
        }

        private static void DFS(int node)
        {
            if(graph[node].Count == 0)
            {
                path.Add(node);
                Console.WriteLine(string.Join(" ", path));
                path.Remove(node);
                return;
            }

            path.Add(node);
            foreach (var child in graph[node])
            {
                DFS(child); 
            }
            path.Remove(node);
        }
    }
}
