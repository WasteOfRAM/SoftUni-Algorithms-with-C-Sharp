
namespace P05.Cable_Network
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;
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

            var budget = int.Parse(Console.ReadLine());
            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            var graph = new List<Edge>[nodesCount];
            for (int i = 0; i < nodesCount; i++)
            {
                graph[i] = new List<Edge>();
            }

            var spanningTree = new HashSet<int>();

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeData = Console.ReadLine().Split();

                var edge = new Edge
                {
                    First = int.Parse(edgeData[0]), Second = int.Parse(edgeData[1]), Weight = int.Parse(edgeData[2])
                };

                graph[edge.First].Add(edge);
                graph[edge.Second].Add(edge);

                if (edgeData.Length == 4)
                {
                    spanningTree.Add(edge.First);
                    spanningTree.Add(edge.Second);
                }
            }

            var usedBudget = Prim(graph, spanningTree, budget);

            Console.WriteLine($"Budget used: {usedBudget}");
        }

        private static int Prim(List<Edge>[] graph, HashSet<int> spanningTree, int budget)
        {
            var usedBudget = 0;

            var priorityQueue = new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Weight.CompareTo(s.Weight)));

            foreach (var node in spanningTree)
            {
                priorityQueue.AddMany(graph[node]);
            }

            while (priorityQueue.Count > 0)
            {
                var minEdge = priorityQueue.RemoveFirst();

                var nonTreeNode = -1;

                if (spanningTree.Contains(minEdge.First) && !spanningTree.Contains(minEdge.Second))
                    nonTreeNode = minEdge.Second;

                if (spanningTree.Contains(minEdge.Second) && !spanningTree.Contains(minEdge.First))
                    nonTreeNode = minEdge.First;

                if(nonTreeNode == -1)
                    continue;

                if(usedBudget + minEdge.Weight > budget)
                    break;

                usedBudget += minEdge.Weight;

                spanningTree.Add(nonTreeNode);
                priorityQueue.AddMany(graph[nonTreeNode]);
            }

            return usedBudget;
        }
    }
}