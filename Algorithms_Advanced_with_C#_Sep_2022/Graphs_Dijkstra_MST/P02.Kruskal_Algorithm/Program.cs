namespace P02.Kruskal_Algorithm
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
        private static List<Edge> forest;
        private static List<Edge> edges;
        private static int[] parent;

        static void Main()
        {
            edges = new List<Edge>();
            forest = new List<Edge>();

            var edgesCount = int.Parse(Console.ReadLine());

            var maxNode = -1;

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeArgs = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                if(maxNode < edgeArgs[0])
                    maxNode = edgeArgs[0];

                if (maxNode < edgeArgs[1])
                    maxNode = edgeArgs[1];

                edges.Add(new Edge{ FirstNode = edgeArgs[0], SecondNode = edgeArgs[1], Weight = edgeArgs[2] });
            }

            parent = new int[maxNode + 1];

            for (int node = 0; node < parent.Length; node++)
            {
                parent[node] = node;
            }

            edges = edges.OrderBy(e => e.Weight).ToList();

            foreach (var edge in edges)
            {
                var firstNodeRoot = FindRoot(edge.FirstNode);
                var secondNodeRoot = FindRoot(edge.SecondNode);

                if(firstNodeRoot == secondNodeRoot)
                    continue;

                parent[secondNodeRoot] = firstNodeRoot;

                forest.Add(edge);
            }

            foreach (var edge in forest)
            {
                Console.WriteLine($"{edge.FirstNode} - {edge.SecondNode}");
            }
        }

        private static int FindRoot(int node)
        {
            while (node != parent[node])
            {
                node = parent[node];
            }

            return node;
        }
    }
}