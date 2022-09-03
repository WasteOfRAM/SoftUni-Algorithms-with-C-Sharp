namespace P03.Prim_Algorithm
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;
    class Edge
    {
        public int FirstNode { get; set; }
        public int SecondNode { get; set; }
        public int Weight { get; set; }
    }

    internal class Program
    {
        private static Dictionary<int, List<Edge>> graph;
        private static HashSet<int> forestNodes;
        private static List<Edge> forestEdges;

        static void Main()
        {
            graph = new Dictionary<int, List<Edge>>();
            forestNodes = new HashSet<int>();
            forestEdges = new List<Edge>();

            var edgesCount = int.Parse(Console.ReadLine());

            GraphFill(edgesCount);

            foreach (var node in graph.Keys)
            {
                if (!forestNodes.Contains(node))
                    Prim(node);
            }

            foreach (var edge in forestEdges)
            {
                Console.WriteLine($"{edge.FirstNode} - {edge.SecondNode}");
            }
        }

        private static void Prim(int startingNode)
        {
            forestNodes.Add(startingNode);

            var priorityQueue = new OrderedBag<Edge>(Comparer<Edge>.Create((first, second) => first.Weight - second.Weight));

            priorityQueue.AddMany(graph[startingNode]);

            while (priorityQueue.Count > 0)
            {
                var minEdge = priorityQueue.RemoveFirst();

                var nonTreeNode = -1;

                if (forestNodes.Contains(minEdge.FirstNode) && !forestNodes.Contains(minEdge.SecondNode))
                    nonTreeNode = minEdge.SecondNode;

                if (forestNodes.Contains(minEdge.SecondNode) && !forestNodes.Contains(minEdge.FirstNode))
                    nonTreeNode = minEdge.FirstNode;

                if(nonTreeNode == -1)
                    continue;

                forestNodes.Add(nonTreeNode);
                forestEdges.Add(minEdge);
                priorityQueue.AddMany(graph[nonTreeNode]);
            }
        }

        private static void GraphFill(int edgesCount)
        {
            for (int i = 0; i < edgesCount; i++)
            {
                var edgeArgs = Console.ReadLine()
                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var nodeOne = edgeArgs[0];
                var nodeTwo = edgeArgs[1];
                var weight = edgeArgs[2];

                var edge = new Edge { FirstNode = nodeOne, SecondNode = nodeTwo, Weight = weight };

                if (!graph.ContainsKey(nodeOne))
                    graph[nodeOne] = new List<Edge>();

                if (!graph.ContainsKey(nodeTwo))
                    graph[nodeTwo] = new List<Edge>();

                graph[nodeOne].Add(edge);
                graph[nodeTwo].Add(edge);
            }
        }
    }
}