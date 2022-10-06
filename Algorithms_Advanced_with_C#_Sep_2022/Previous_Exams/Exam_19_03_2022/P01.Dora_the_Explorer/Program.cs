namespace P01.Dora_the_Explorer
{
    using System;
    using System.Linq;
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
        private static Dictionary<int, List<Edge>> edgesByNode;
        private static int[] prev;
        private static double[] time;

        static void Main()
        {
            var edgeCount = int.Parse(Console.ReadLine());

            edgesByNode = new Dictionary<int, List<Edge>>();


            for (int i = 0; i < edgeCount; i++)
            {
                var edgeArgs = Console.ReadLine()
                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var nodeOne = edgeArgs[0];
                var nodeTwo = edgeArgs[1];
                var weight = edgeArgs[2];

                var edge = new Edge { First = nodeOne, Second = nodeTwo, Weight = weight };

                if (!edgesByNode.ContainsKey(nodeOne))
                    edgesByNode[nodeOne] = new List<Edge>();

                if (!edgesByNode.ContainsKey(nodeTwo))
                    edgesByNode[nodeTwo] = new List<Edge>();

                edgesByNode[nodeOne].Add(edge);
                edgesByNode[nodeTwo].Add(edge);
            }

            var timeSpent = int.Parse(Console.ReadLine());

            var startNode = int.Parse(Console.ReadLine());
            var endNode = int.Parse(Console.ReadLine());

            var nodesCount = edgesByNode.Keys.Max() + 1;

            time = new double[nodesCount];
            prev = new int[nodesCount];

            for (int i = 0; i < prev.Length; i++)
            {
                prev[i] = -1;
            }

            for (int node = 0; node < time.Length; node++)
            {
                time[node] = double.PositiveInfinity;
            }

            time[startNode] = 0;

            var priorityQueue = new OrderedBag<int>(Comparer<int>.Create((firstNode, secondNode) => (int)(time[firstNode] - time[secondNode]))) { startNode };

            DijkstraBfs(priorityQueue, endNode, timeSpent);

            var path = new Stack<int>();
            var currentNode = endNode;

            while (currentNode != -1)
            {
                path.Push(currentNode);
                currentNode = prev[currentNode];
            }

            Console.WriteLine($"Total time: {time[endNode] - timeSpent}");
            Console.WriteLine(string.Join(Environment.NewLine, path));

        }

        private static void DijkstraBfs(OrderedBag<int> priorityQueue, int endNode, int timeSpent)
        {
            while (priorityQueue.Count != 0)
            {
                var minNode = priorityQueue.RemoveFirst();

                if(minNode == endNode || double.IsPositiveInfinity(time[minNode]))
                {
                    break;
                }

                foreach (var edge in edgesByNode[minNode])
                {
                    var otherNode = edge.First == minNode ? edge.Second : edge.First;

                    if (double.IsPositiveInfinity(time[otherNode]))
                        priorityQueue.Add(otherNode);

                    var newTime = time[minNode] + edge.Weight + timeSpent;

                    if (!(newTime < time[otherNode])) continue;

                    prev[otherNode] = minNode;
                    time[otherNode] = newTime;

                    priorityQueue = new OrderedBag<int>(priorityQueue,
                        Comparer<int>.Create((firstNode, secondNode) =>
                            (int)(time[firstNode] - time[secondNode])));
                }
            }
        }
    }
}