using System;
using System.Linq;
using System.Collections.Generic;
using Wintellect;
using Wintellect.PowerCollections;

namespace P01.Dijkstra_s_Algorithm
{
    class Edge
    {
        public int FirstNode { get; set; }
        public int SecondNode { get; set; }
        public int Weight { get; set; }
    }

    internal class Program
    {
        private static Dictionary<int, List<Edge>> edgesByNode;
        private static double[] distances;
        private static int[] previousNode;

        static void Main()
        {
            edgesByNode = new Dictionary<int, List<Edge>>();

            var edgesCount = int.Parse(Console.ReadLine());

            GraphFill(edgesCount);

            var startNode = int.Parse(Console.ReadLine());
            var endNode = int.Parse(Console.ReadLine());

            var nodesCount = edgesByNode.Keys.Max() + 1;

            distances = new double[nodesCount];
            previousNode = new int[nodesCount];
            //Array.Fill(previousNode, -1);

            for (int i = 0; i < previousNode.Length; i++)
            {
                previousNode[i] = -1;
            }

            for (int node = 0; node < distances.Length; node++)
            {
                distances[node] = double.PositiveInfinity;
            }

            distances[startNode] = 0;

            var priorityQueue = new OrderedBag<int>(Comparer<int>.Create((firstNode, secondNode) => (int)(distances[firstNode] - distances[secondNode]))) { startNode };

            DijkstraBfs(priorityQueue, endNode);

            if (double.IsPositiveInfinity(distances[endNode]))
            {
                Console.WriteLine("There is no such path.");
            }
            else
            {
                var currentNode = endNode;
                var path = new Stack<int>();

                while (currentNode != -1)
                {
                    path.Push(currentNode);
                    currentNode = previousNode[currentNode];
                }

                Console.WriteLine(distances[endNode]);
                Console.WriteLine(string.Join(" ", path));
            }
        }

        private static void DijkstraBfs(OrderedBag<int> priorityQueue, int endNode)
        {
            while (priorityQueue.Count != 0)
            {
                var minNode = priorityQueue.RemoveFirst();

                if (minNode == endNode || double.IsPositiveInfinity(distances[minNode]))
                    break;

                foreach (var edge in edgesByNode[minNode])
                {
                    var otherNode = edge.FirstNode == minNode ? edge.SecondNode : edge.FirstNode;

                    if (double.IsPositiveInfinity(distances[otherNode]))
                        priorityQueue.Add(otherNode);

                    var newDistance = distances[minNode] + edge.Weight;

                    if (!(newDistance < distances[otherNode])) continue;

                    previousNode[otherNode] = minNode;
                    distances[otherNode] = newDistance;

                    priorityQueue = new OrderedBag<int>(priorityQueue,
                        Comparer<int>.Create((firstNode, secondNode) =>
                            (int)(distances[firstNode] - distances[secondNode])));
                }
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

                if (!edgesByNode.ContainsKey(nodeOne))
                    edgesByNode[nodeOne] = new List<Edge>();

                if (!edgesByNode.ContainsKey(nodeTwo))
                    edgesByNode[nodeTwo] = new List<Edge>();

                edgesByNode[nodeOne].Add(edge);
                edgesByNode[nodeTwo].Add(edge);
            }
        }
    }
}