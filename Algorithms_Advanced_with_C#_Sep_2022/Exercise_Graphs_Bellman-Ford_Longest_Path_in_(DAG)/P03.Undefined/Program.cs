namespace P03.Undefined
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge
    {
        public int From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }
    }

    internal class Program
    {
        private static List<Edge> graph;
        private static double[] distances;
        private static int[] prev;

        static void Main()
        {
            // Bellman-Ford

            graph = new List<Edge>();

            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                graph.Add(new Edge { From = edgeData[0], To = edgeData[1], Weight = edgeData[2] });
            }

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            distances = new double[nodesCount + 1];
            prev = new int[nodesCount + 1];

            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = double.PositiveInfinity;
                prev[i] = -1;
            }

            distances[source] = 0;

            try
            {
                BellmanFord(nodesCount);

                var path = PathExtraction(destination);

                Console.WriteLine(path);
                Console.WriteLine(distances[destination]);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static string PathExtraction(int destination)
        {
            var path = new Stack<int>();

            var currentNode = destination;

            while (currentNode != -1)
            {
                path.Push(currentNode);
                currentNode = prev[currentNode];
            }

            return string.Join(" ", path);
        }

        private static void BellmanFord(int nodesCount)
        {
            for (int i = 0; i < nodesCount - 1; i++)
            {
                var updated = false;

                foreach (var edge in graph)
                {
                    if (double.IsPositiveInfinity(distances[edge.From]))
                        continue;

                    var newDistance = distances[edge.From] + edge.Weight;

                    if (newDistance < distances[edge.To])
                    {
                        distances[edge.To] = newDistance;
                        prev[edge.To] = edge.From;
                        updated = true;
                    }
                }

                if (!updated)
                    break;
            }

            foreach (var edge in graph)
            {
                var newDistance = distances[edge.From] + edge.Weight;

                if (newDistance < distances[edge.To])
                {
                    throw new ArgumentException("Undefined");
                }
            }
        }
    }
}