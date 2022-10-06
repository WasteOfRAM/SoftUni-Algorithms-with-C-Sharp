namespace P03.The_Boring_Company
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Edge
    {
        public int FirstNode { get; set; }
        public int SecondNode { get; set; }
        public int Weight { get; set; }
    }

    internal class Program
    {
        

        static void Main()
        {
            var graph = new List<Edge>();
            
            var nodesCount = int.Parse(Console.ReadLine());
            var edgeCount = int.Parse(Console.ReadLine());
            var connectedNodes = int.Parse(Console.ReadLine());

            var parent = new int[nodesCount];

            for (int node = 0; node < parent.Length; node++)
            {
                parent[node] = node;
            }

            for (int i = 0; i < edgeCount; i++)
            {
                var edgeData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                graph.Add(new Edge { FirstNode = edgeData[0], SecondNode = edgeData[1], Weight = edgeData[2] });
            }

            for (int i = 0; i < connectedNodes; i++)
            {
                var edgeData = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                var firstNode = edgeData[0];
                var secondNode = edgeData[1];

                parent[secondNode] = firstNode;
            }

            var totalCost = 0;
            foreach (var edge in graph.OrderBy(e => e.Weight))
            {
                var firstNodeRoot = FindRoot(edge.FirstNode, parent);
                var secondNodeRoot = FindRoot(edge.SecondNode, parent);

                if (firstNodeRoot == secondNodeRoot)
                {
                    continue;
                }

                parent[firstNodeRoot] = secondNodeRoot;

                totalCost += edge.Weight;
            }

            Console.WriteLine($"Minimum budget: {totalCost}");
        }

        private static int FindRoot(int node, int[] parent)
        {
            while (node != parent[node])
            {
                node = parent[node];
            }

            return node;
        }
    }
}