using System.ComponentModel;

namespace P02.Max_Flow
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main()
        {
            var nodeCount = int.Parse(Console.ReadLine());

            var graph = GraphFill(nodeCount);

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            var parent = new int[nodeCount];
            Array.Fill(parent, -1);

            var maxFlow = 0;

            while (BFS(graph, source, destination, parent))
            {
                var minFlow = GetMinFlow(destination, parent, graph);

                ApplyFlow(destination, minFlow, parent, graph);

                maxFlow += minFlow;
            }

            Console.WriteLine($"Max flow = {maxFlow}");
        }

        private static void ApplyFlow(int node, int flow, int[] parent, int[,] graph)
        {
            while (parent[node] != -1)
            {
                var prev = parent[node];
                graph[prev, node] -= flow;
                node = prev;
            }
        }

        private static int GetMinFlow(int node, int[] parent, int[,] graph)
        {
            var minFlow = int.MaxValue;

            while (parent[node] != -1)
            {
                var prev = parent[node];
                var flow = graph[prev, node];

                if(flow < minFlow) minFlow = flow;

                node = prev;
            }

            return minFlow;
        }

        private static bool BFS(int[,] graph, int source, int destination, int[] parents)
        {
            var visited = new bool[graph.GetLength(0)];
            var queue = new Queue<int>();

            visited[source] = true;
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                for (int child = 0; child < graph.GetLength(1); child++)
                {
                    if (!visited[child] && graph[node, child] > 0)
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                        parents[child] = node;
                    }
                }
            }

            return visited[destination];
        }

        private static int[,] GraphFill(int n)
        {
            var result = new int[n, n];

            for (int node = 0; node < n; node++)
            {
                var row = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int child = 0; child < row.Length; child++)
                {
                    result[node, child] = row[child];
                }
            }

            return result;
        }
    }
}