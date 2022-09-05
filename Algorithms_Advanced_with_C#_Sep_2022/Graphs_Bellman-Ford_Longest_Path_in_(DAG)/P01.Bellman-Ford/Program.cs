namespace P01.Bellman_Ford
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

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
            graph = new List<Edge>();

            var nodesCount = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            distances = new double[nodesCount + 1];
            Array.Fill(distances, double.PositiveInfinity);

            prev = new int[nodesCount +1];
            Array.Fill(prev, -1);

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                graph.Add(new Edge{From = edgeData[0], To = edgeData[1], Weight = edgeData[2] });
            }

            var startNode = int.Parse(Console.ReadLine());
            var destinationNode = int.Parse(Console.ReadLine());

            distances[startNode] = 0;

            try
            {
                BellmanFord(nodesCount);

                var path = PathExtraction(destinationNode);

                Console.WriteLine(string.Join(" ", path));
                Console.WriteLine(distances[destinationNode]);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            
        }

        private static Stack<int> PathExtraction(int destinationNode)
        {
            var path = new Stack<int>();
            var currentNode = destinationNode;

            while (currentNode != -1)
            {
                path.Push(currentNode);
                currentNode = prev[currentNode];
            }

            return path;
        }

        private static void BellmanFord(int nodesCount)
        {
            for (int i = 0; i < nodesCount - 1; i++)
            {
                var updated = false;

                foreach (var edge in graph)
                {
                    if (double.IsPositiveInfinity(distances[edge.From]))
                    {
                        continue;
                    }

                    var newDistance = distances[edge.From] + edge.Weight;
                    if (newDistance < distances[edge.To])
                    {
                        distances[edge.To] = newDistance;
                        prev[edge.To] = edge.From;
                        updated = true;
                    }
                }

                if(!updated)
                    break;
            }

            foreach (var edge in graph)
            {
                var newDistance = distances[edge.From] + edge.Weight;
                if (newDistance < distances[edge.To])
                {
                    throw new ArgumentException("Negative Cycle Detected");
                }
            }
        }
    }
}