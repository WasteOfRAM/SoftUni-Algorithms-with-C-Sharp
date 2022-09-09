using System.Runtime.InteropServices;

namespace P04.Big_Trip
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
        private static Dictionary<int, List<Edge>> edgeByNode;
        private static double[] times;
        private static int[] prev;

        static void Main()
        {
            edgeByNode = new Dictionary<int, List<Edge>>();

            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var edge = new Edge { From = edgeData[0], To = edgeData[1], Weight = edgeData[2] };

                if (!edgeByNode.ContainsKey(edge.From))
                    edgeByNode[edge.From] = new List<Edge>();

                if (!edgeByNode.ContainsKey(edge.To))
                    edgeByNode[edge.To] = new List<Edge>();

                edgeByNode[edge.From].Add(edge);
            }

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            times = new double[nodesCount + 1];
            prev = new int[nodesCount + 1];

            for (int i = 0; i < times.Length; i++)
            {
                times[i] = double.NegativeInfinity;
                prev[i] = -1;
            }

            times[source] = 0;

            var sortedNodes = TopologicalSort();

            LongestPath(sortedNodes);

            var path = PathExtraction(destination);

            Console.WriteLine(times[destination]);
            Console.WriteLine(path);
        }

        private static string PathExtraction(int destination)
        {
            var path = new Stack<int>();

            var currentNode = destination;

            while (currentNode != -1)
            {
                path.Push(currentNode);
                currentNode = prev[currentNode];
            }

            return string.Join(" ", path);
        }

        private static void LongestPath(Stack<int> sortedNodes)
        {
            while (sortedNodes.Count > 0)
            {
                var node = sortedNodes.Pop();

                foreach (var edge in edgeByNode[node])
                {
                    var newTime = times[edge.From] + edge.Weight;

                    if (newTime > times[edge.To])
                    {
                        times[edge.To] = newTime;
                        prev[edge.To] = node;
                    }
                }
            }
        }

        private static Stack<int> TopologicalSort()
        {
            var result = new Stack<int>();
            var visited = new HashSet<int>();

            foreach (var node in edgeByNode.Keys)
            {
                DFS(node, result, visited);
            }

            return result;
        }

        private static void DFS(int node, Stack<int> result, HashSet<int> visited)
        {
            if(visited.Contains(node))
                return;

            visited.Add(node);

            foreach (var edge in edgeByNode[node])
            {
                DFS(edge.To, result, visited);
            }

            result.Push(node);
        }
    }
}