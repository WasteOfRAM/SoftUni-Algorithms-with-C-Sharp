namespace P01.Most_Reliable_Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }
    }

    internal class Program
    {
        private static List<Edge>[] graph;
        private static double[] reliability;
        private static int[] prev;

        static void Main()
        {

            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            graph = new List<Edge>[nodesCount];

            for (int i = 0; i < nodesCount; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeData = Console.ReadLine().Split();

                var firstNode = int.Parse(edgeData[0]);
                var secondNode = int.Parse(edgeData[1]);
                var weight = int.Parse(edgeData[2]);

                var edge = new Edge { First = firstNode, Second = secondNode, Weight = weight };

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }

            var start = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            reliability = new double[nodesCount];
            prev = new int[nodesCount];

            for (int i = 0; i < nodesCount; i++)
            {
                reliability[i] = double.NegativeInfinity;
                prev[i] = -1;
            }

            reliability[start] = 100;

            var priorityQueue = new OrderedBag<int>(Comparer<int>.Create((f, s) => reliability[s].CompareTo(reliability[f]))) { start };

            while (priorityQueue.Count > 0)
            {
                var node = priorityQueue.RemoveFirst();

                if (node == destination || double.IsNegativeInfinity(reliability[node]))
                    break;

                foreach (var edge in graph[node])
                {
                    var child = edge.First == node ? edge.Second : edge.First;

                    if (double.IsNegativeInfinity(reliability[child]))
                        priorityQueue.Add(child);

                    var newReliability = reliability[node] * edge.Weight / 100.0;

                    if (newReliability > reliability[child])
                    {
                        reliability[child] = newReliability;
                        prev[child] = node;

                        priorityQueue = new OrderedBag<int>(priorityQueue, Comparer<int>.Create((f, s) => reliability[s].CompareTo(reliability[f])));
                    }
                }
            }

            var path = new Stack<int>();
            var currentNode = destination;

            while (currentNode != -1)
            {
                path.Push(currentNode);
                currentNode = prev[currentNode];
            }

            Console.WriteLine($"Most reliable path reliability: {reliability[destination]:f2}%");
            Console.WriteLine(string.Join(" -> ", path));
        }
    }
}