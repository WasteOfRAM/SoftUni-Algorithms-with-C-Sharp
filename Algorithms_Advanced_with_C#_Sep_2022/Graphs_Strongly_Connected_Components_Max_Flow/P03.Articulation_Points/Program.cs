namespace P03.Articulation_Points
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] depths;
        private static int[] lowpoints;
        private static int?[] parents;
        private static List<int> points;

        static void Main()
        {
            var nodeCount = int.Parse(Console.ReadLine());
            var linesCount = int.Parse(Console.ReadLine());

            graph = new List<int>[nodeCount];
            visited = new bool[nodeCount];
            depths = new int[nodeCount];
            lowpoints = new int[nodeCount];
            parents = new int?[nodeCount];
            points = new List<int>();

            for (int i = 0; i < nodeCount; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < linesCount; i++)
            {
                var line = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                var node = line[0];
                graph[node].AddRange(line.Skip(1));
            }

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node]) continue;

                FindArticulationPoints(node, 1);
            }

            Console.WriteLine($"Articulation points: {string.Join(", ", points)}");
        }

        // DFS
        private static void FindArticulationPoints(int node, int currentDepth)
        {
            visited[node] = true;
            depths[node] = currentDepth;
            lowpoints[node] = currentDepth;

            var children = 0;
            var isArticulation = false;

            foreach (var child in graph[node])
            {
                if (!visited[child])
                {
                    parents[child] = node;
                    FindArticulationPoints(child, currentDepth + 1);
                    children += 1;

                    if (lowpoints[child] >= currentDepth)
                        isArticulation = true;

                    lowpoints[node] = Math.Min(lowpoints[node], lowpoints[child]);
                }
                else if (parents[node] != child)
                {
                    lowpoints[node] = Math.Min(lowpoints[node], depths[child]);
                }
            }

            if (parents[node] == null && children > 1 || parents[node] != null && isArticulation)
                points.Add(node);
        }
    }
}