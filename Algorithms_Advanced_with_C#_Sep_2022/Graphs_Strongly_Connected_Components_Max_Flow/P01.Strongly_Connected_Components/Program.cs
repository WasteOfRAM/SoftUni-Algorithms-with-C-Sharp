namespace P01.Strongly_Connected_Components
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            var nodeCount = int.Parse(Console.ReadLine());
            var edgeCount = int.Parse(Console.ReadLine());

            var graph = new List<int>[nodeCount];
            var reversedGraph = new List<int>[nodeCount];
            var visited = new bool[nodeCount];
            var sorted = new Stack<int>();

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
                reversedGraph[i] = new List<int>();
            }

            for (int i = 0; i < edgeCount; i++)
            {
                var line = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                var node = line[0];

                for (int j = 0; j < line.Length; j++)
                {
                    var child = line[j];
                    graph[node].Add(child);
                    reversedGraph[child].Add(node);
                }
            }

            for (var node = 0; node < graph.Length; node++)
            {
                DFS(node, graph, visited, sorted); 
            }

            visited = new bool[reversedGraph.Length];

            Console.WriteLine("Strongly Connected Components:");

            while (sorted.Count > 0)
            {
                var node = sorted.Pop();
                var connectedComponents = new Stack<int>();

                if (visited[node]) continue;

                DFS(node, reversedGraph, visited, connectedComponents);

                Console.WriteLine($"{{{string.Join(", ", connectedComponents)}}}");
            }
        }

        private static void DFS(int node, List<int>[] graph, bool[] visited, Stack<int> result)
        {
            if (visited[node]) return;

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child, graph, visited, result);
            }

            result.Push(node);
        }
    }
}