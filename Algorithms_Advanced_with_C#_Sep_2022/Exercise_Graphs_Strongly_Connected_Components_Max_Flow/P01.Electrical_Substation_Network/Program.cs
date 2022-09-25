namespace P01.Electrical_Substation_Network
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main()
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var linesCount = int.Parse(Console.ReadLine());

            var graph = new List<int>[nodesCount];
            var reversedGraph = new List<int>[nodesCount];

            for (int i = 0; i < nodesCount; i++)
            {
                graph[i] = new List<int>();
                reversedGraph[i] = new List<int>();
            }

            for (int i = 0; i < linesCount; i++)
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

            var sorted = new Stack<int>();
            var visited = new bool[nodesCount];

            for (int node = 0; node < graph.Length; node++)
            {
                DFS(node, graph, visited, sorted);
            }

            visited = new bool[nodesCount];
            

            while (sorted.Count > 0)
            {
                var node = sorted.Pop();

                if (visited[node]) continue;

                var components = new Stack<int>();

                DFS(node, reversedGraph, visited, components);

                Console.WriteLine($"{string.Join(", ", components)}");
            }
        }

        private static void DFS(int node, List<int>[] targetGraph, bool[] visited, Stack<int> stack)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in targetGraph[node])
            {
                DFS(child, targetGraph, visited, stack);
            }

            stack.Push(node);
        }
    }
}