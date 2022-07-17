using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Path_Finder
{
    internal class Program
    {
        private static List<int>[] graph;
        private static Stack<int> currentPath;

        static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());

            graph = new List<int>[nodesCount];

            for (int i = 0; i < nodesCount; i++)
            {
                graph[i] = new List<int>();

                var nodeCildren = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                if (nodeCildren.Length > 0)
                    graph[i].AddRange(nodeCildren);
            }

            int pathsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < pathsCount; i++)
            {
                currentPath = new Stack<int>();

                var pathToFind = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int startNode = pathToFind[0];
                int destination = pathToFind[^1];

                bool validPath = false;

                validPath = PathFinder(startNode, destination, pathToFind, validPath);

                Console.WriteLine(validPath ? "yes" : "no");
            }
        }

        private static bool PathFinder(int startNode, int destination, int[] pathToFind, bool validPath)
        {
            if (startNode == destination)
            {
                currentPath.Push(startNode);
                int[] que = currentPath.Reverse().ToArray();
                if (que.SequenceEqual(pathToFind))
                    return true;

                currentPath.Pop();
            }

            currentPath.Push(startNode);
            foreach (var child in graph[startNode])
            {
                validPath = PathFinder(child, destination, pathToFind, validPath);
                currentPath.Pop();
            }

            return validPath;
        }
    }
}
