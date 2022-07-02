using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Cycles_in_Graph
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;

        static void Main()
        {
            graph = new Dictionary<string, List<string>>();

            string edge;
            while ((edge = Console.ReadLine()) != "End")
            {
                var edgeSplit = edge.Split("-").ToArray();
                var parent = edgeSplit[0];
                var child = edgeSplit[1];

                if(!graph.ContainsKey(parent))
                    graph[parent] = new List<string>();

                if (!graph.ContainsKey(child))
                    graph[child] = new List<string>();

                graph[parent].Add(child);
            }

            bool isCyclic = false;

            foreach (var vert in graph)
            {
                if ((isCyclic = BFS(vert.Key)) == true)
                {
                    break;
                }
            }

            Console.WriteLine($"Acyclic: {(isCyclic ? "No" : "Yes")}");
        }

        private static bool BFS(string start)
        {
            var queue = new Queue<string>();
            queue.Enqueue(start);

            visited = new HashSet<string> { start };
            var cyclic = new HashSet<string> { start };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                foreach (var child in graph[node])
                {
                    if (cyclic.Contains(child))
                        return true;

                    if (visited.Contains(child))
                        continue;

                    queue.Enqueue(child);
                    visited.Add(child);
                    cyclic.Add(child);
                }
            }

            return false;
        }
    }
}
