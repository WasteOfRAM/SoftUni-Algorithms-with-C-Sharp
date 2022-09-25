namespace P03.Find_Bi_Connected_Components
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private static List<int>[] graph;
        private static int[] depth;
        private static int[] lowPoint;
        private static bool[] visited;
        private static int[] parent;

        private static Stack<int> stack;
        private static List<HashSet<int>> components;

        static void Main()
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var edgeCount = int.Parse(Console.ReadLine());

            graph = new List<int>[nodesCount];
            depth = new int[graph.Length];
            lowPoint = new int[graph.Length];
            visited = new bool[graph.Length];
            parent = new int[graph.Length];
            stack = new Stack<int>();
            components = new List<HashSet<int>>();

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
                parent[i] = -1;
            }

            for (int i = 0; i < edgeCount; i++)
            {
                var edgeData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var firstNode = edgeData[0];
                var secondNode = edgeData[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);
            }

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node])
                    continue;

                FindArticulationPoints(node, 1);

                var lastComponent = stack.ToHashSet();
                components.Add(lastComponent);
            }

            Console.WriteLine($"Number of bi-connected components: {components.Count}");
        }

        private static void FindArticulationPoints(int node, int currentDepth)
        {
            visited[node] = true;
            depth[node] = currentDepth;
            lowPoint[node] = currentDepth;
            var childCount = 0;

            foreach (var child in graph[node])
            {
                if (!visited[child])
                {
                    stack.Push(node);
                    stack.Push(child);

                    parent[child] = node;
                    FindArticulationPoints(child, currentDepth + 1);
                    childCount++;

                    if (parent[node] != -1 && lowPoint[child] >= depth[node] ||
                        parent[node] == -1 && childCount > 1)
                    {
                        var component = new HashSet<int>();

                        while (true)
                        {
                            var stackChild = stack.Pop();
                            var stackNode = stack.Pop();

                            component.Add(stackNode);
                            component.Add(stackChild);

                            if (stackNode == node &&
                                stackChild == child)
                            {
                                break;
                            }
                        }

                        components.Add(component);
                    }

                    lowPoint[node] = Math.Min(lowPoint[node], lowPoint[child]);
                }
                else if (parent[node] != child &&
                         depth[child] < lowPoint[node])
                {
                    lowPoint[node] = depth[child];

                    stack.Push(node);
                    stack.Push(child);
                }
            }

            
        }
    }
}