using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.Road_Reconstruction
{
    internal class Program
    {
        private static List<int>[] graph;
        private static List<Edge> edges;
        private static bool[] visited;

        static void Main()
        {
            int buildings = int.Parse(Console.ReadLine());
            int streets = int.Parse(Console.ReadLine());

            graph = new List<int>[buildings];
            edges = new List<Edge>();
            

            for (int building = 0; building < buildings; building++)
            {
                graph[building] = new List<int>();
            }

            for (int i = 0; i < streets; i++)
            {
                var street = Console.ReadLine().Split(" - ").Select(int.Parse).ToArray();

                int first = street[0];
                int second = street[1];

                graph[first].Add(second);
                graph[second].Add(first);

                edges.Add(new Edge { First = first, Second = second });
            }

            Console.WriteLine("Important streets:");

            foreach (var edge in edges)
            {
                graph[edge.First].Remove(edge.Second);
                graph[edge.Second].Remove(edge.First);

                visited = new bool[buildings];

                DFS(0);

                if(visited.Contains(false))
                    Console.WriteLine(edge);

                graph[edge.First].Add(edge.Second);
                graph[edge.Second].Add(edge.First);
            }
        }

        private static void DFS(int node)
        {
            if (visited[node])
                return;

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child);
            }
        }
    }

    class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }

        public override string ToString()
        {
            if (First < Second)
                return $"{First} {Second}";

            return $"{Second} {First}";
        }
    }
}
