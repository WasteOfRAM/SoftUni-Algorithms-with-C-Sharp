using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Guards
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;

        static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            int edgeCount = int.Parse(Console.ReadLine());

            graph = new List<int>[nodesCount + 1];
            visited = new bool[nodesCount + 1];

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 1; i <= edgeCount; i++)
            {
                int[] edge = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int parent = edge[0];
                int child = edge[1];

                graph[parent].Add(child);
            }

            int startNode = int.Parse(Console.ReadLine());

            DFS(startNode);

            var unreachable = new HashSet<int>();

            for (int i = 1; i < visited.Length; i++)
            {
                if (!visited[i])
                    unreachable.Add(i);
            }

            Console.WriteLine(string.Join(" ", unreachable));
        }

        private static void DFS(int startNode)
        {
            if (graph[startNode].Count == 0)
                return;

            visited[startNode] = true;

            foreach (var child in graph[startNode])
            {
                if (!visited[child])
                {
                    visited[child] = true;
                    DFS(child);
                }
            }
        }
    }
}
