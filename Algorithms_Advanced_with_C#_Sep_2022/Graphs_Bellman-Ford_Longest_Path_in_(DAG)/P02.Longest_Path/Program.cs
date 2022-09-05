using System.ComponentModel.Design;

namespace P02.Longest_Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge
    {
        public int From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }
    }

    internal class Program
    {
        private static Dictionary<int, List<Edge>> edgesByNode;
        private static double[] distances;

        static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            edgesByNode = new Dictionary<int, List<Edge>>();

            distances = new double[nodes + 1];
            Array.Fill(distances, double.NegativeInfinity);

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var from = edgeData[0];
                var to = edgeData[1];
                var weight = edgeData[2];

                if(!edgesByNode.ContainsKey(from))
                    edgesByNode[from] = new List<Edge>();

                if (!edgesByNode.ContainsKey(to))
                    edgesByNode[to] = new List<Edge>();

                edgesByNode[from].Add(new Edge{From = from, To = to, Weight = weight});
            }

            var start = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            distances[start] = 0;

            var sorted = TopologicalSort();

            LongestPath(sorted);

            Console.WriteLine(distances[destination]);
        }

        // Longest Path in (DAG)
        private static void LongestPath(Stack<int> sorted)
        {
            while (sorted.Count > 0)
            {
                var nodes = sorted.Pop();

                foreach (var edge in edgesByNode[nodes])
                {
                    var newDistance = distances[edge.From] + edge.Weight;

                    if (newDistance > distances[edge.To])
                        distances[edge.To] = newDistance;
                }
            }
        }

        private static Stack<int> TopologicalSort()
        {
            var result = new Stack<int>();
            var visited = new HashSet<int>();

            foreach (var node in edgesByNode.Keys)
            {
                DFS(node, visited, result);
            }

            return result;
        }

        private static void DFS(int node, HashSet<int> visited, Stack<int> result)
        {
            if(visited.Contains(node))
                return;
            
            visited.Add(node);

            foreach (var edge in edgesByNode[node])
            {
                DFS(edge.To, visited, result);
            }

            result.Push(node);
        }
    }
}