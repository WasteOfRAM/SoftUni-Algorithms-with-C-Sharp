using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Rumors
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parent;

        static void Main()
        {
            int peopleCount = int.Parse(Console.ReadLine());
            int conections = int.Parse(Console.ReadLine());

            graph = new List<int>[peopleCount + 1];
            visited = new bool[peopleCount + 1];
            parent = new int[peopleCount + 1];

            Array.Fill(parent, -1);

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < conections; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int parent = input[0];
                int child = input[1];

                graph[parent].Add(child);
                graph[child].Add(parent);
            }

            int start = int.Parse(Console.ReadLine());

            BFS(start);
        }

        private static void BFS(int start)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node != start)
                {
                    var path = GetPath(node);

                    Console.WriteLine($"{start} -> {node} ({path.Count - 1})");
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

        private static Stack<int> GetPath(int currentNode)
        {
            var path = new Stack<int>();

            var node = currentNode;

            while (node != -1)
            {
                path.Push(node);
                node = parent[node];
            }

            return path;
        }
    }
}
