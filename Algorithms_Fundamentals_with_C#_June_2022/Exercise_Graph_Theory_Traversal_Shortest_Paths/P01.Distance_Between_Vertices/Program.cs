using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Distance_Between_Vertices
{
    internal class Program
    {
        private static Dictionary<int, List<int>> graph;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int pairs = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int parent = int.Parse(line[0]);

                if (line.Length == 1)
                    graph[parent] = new List<int>();
                else
                    graph[parent] = line[1].Split().Select(int.Parse).ToList();
            }

            for (int pair = 0; pair < pairs; pair++)
            {
                var input = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int start = input[0];
                int end = input[1];

                int pathLenght = BFS(start, end);

                Console.WriteLine($"{{{start}, {end}}} -> {pathLenght}");
            }

        }

        private static int BFS(int startNode, int destination)
        {
            var queue = new Queue<int>();
            var visited = new HashSet<int> { startNode };
            var parent = new Dictionary<int, int> { { startNode, -1 } };

            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return GetPath(parent, destination);
                }

                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(child);
                        visited.Add(child);
                        parent[child] = node;
                    }
                }
            }

            return -1;
        }

        private static int GetPath(Dictionary<int, int> parent, int destination)
        {
            int steps = 0;
            var node = destination;

            while (node != -1)
            {
                node = parent[node];
                steps++;
            }

            return steps - 1;
        }
    }
}
