using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Shortest_Path
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parent;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            graph = new List<int>[n + 1];
            visited = new bool[graph.Length];
            parent = new int[graph.Length];

            Array.Fill(parent, -1);

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                var edge = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int firstNode = edge[0];
                int secondNode = edge[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);
            }

            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            BFS(start, end);
        }

        private static void BFS(int startNode, int destination)
        {
            var queue = new Queue<int>();

            queue.Enqueue(startNode);
            visited[startNode] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if(node == destination)
                {
                    var path = GetPath(destination);

                    Console.WriteLine($"Shortest path length is: {path.Count - 1}");
                    Console.WriteLine(string.Join(" ", path));

                    break;
                }

                foreach (var child in graph[node])
                {
                    if (!visited[child])
                    {
                        parent[child] = node;
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }
        }

        private static Stack<int> GetPath(int destination)
        {
            var path = new Stack<int>();

            var node = destination;

            while (node != -1)
            {
                path.Push(node);
                node = parent[node];
            }

            return path;
        }
    }
}
