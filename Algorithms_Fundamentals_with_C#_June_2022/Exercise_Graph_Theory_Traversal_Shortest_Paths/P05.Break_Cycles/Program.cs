﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.Break_Cycles
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static List<Edge> edges;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" -> ");
                var perant = input[0];
                var children = input[1].Split().ToList();

                graph[perant] = children;

                foreach (var child in children)
                {
                    edges.Add(new Edge { First = perant, Second = child });
                }
            }

            edges = edges.OrderBy(e => e.First).ThenBy(e => e.Second).ToList();

            var removedEdges = new List<Edge>();

            foreach (var edge in edges)
            {
                var removed = graph[edge.First].Remove(edge.Second) && graph[edge.Second].Remove(edge.First);

                if (!removed)
                    continue;

                if(BFS(edge.First, edge.Second))
                {
                    removedEdges.Add(edge);
                }
                else
                {
                    graph[edge.First].Add(edge.Second);
                    graph[edge.Second].Add(edge.First);
                }
            }

            Console.WriteLine($"Edges to remove: {removedEdges.Count}");

            foreach (var edge in removedEdges)
            {
                Console.WriteLine($"{edge.First} - {edge.Second}");
            }
        }

        private static bool BFS(string start, string destination)
        {
            var queue = new Queue<string>();
            queue.Enqueue(start);
            var visited = new HashSet<string> { start };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                    return true;

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                        continue;

                    queue.Enqueue(child);
                    visited.Add(child);
                }
            }

            return false;
        }
    }

    class Edge
    {
        public string First { get; set; }
        public string Second { get; set; }
    }
}
