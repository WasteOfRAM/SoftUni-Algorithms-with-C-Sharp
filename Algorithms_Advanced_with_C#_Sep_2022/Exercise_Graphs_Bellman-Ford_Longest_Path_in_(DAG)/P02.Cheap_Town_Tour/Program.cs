namespace P02.Cheap_Town_Tour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }
    }

    internal class Program
    {
        static void Main()
        {
            // Kruskal

            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            var graph = new List<Edge>();

            var parent = new int[nodesCount];

            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeData = Console.ReadLine().Split(" - ");
                var first = int.Parse(edgeData[0]);
                var second = int.Parse(edgeData[1]);
                var weight = int.Parse(edgeData[2]);

                graph.Add(new Edge{First = first, Second = second, Weight = weight});
            }

            var totalCost = 0;

            foreach (var edge in graph.OrderBy(e => e.Weight))
            {
                var firstNodeRoot = FindRoot(edge.First, parent);
                var secondNodeRoot = FindRoot(edge.Second, parent);

                if(firstNodeRoot == secondNodeRoot)
                    continue;

                parent[firstNodeRoot] = secondNodeRoot;

                totalCost += edge.Weight;
            }

            Console.WriteLine($"Total cost: {totalCost}");
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