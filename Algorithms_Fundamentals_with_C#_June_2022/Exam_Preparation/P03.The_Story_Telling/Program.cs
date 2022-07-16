using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.The_Story_Telling
{
    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> story;

        static void Main()
        {
            graph = new Dictionary<string, List<string>>();
            story = new HashSet<string>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split("->", StringSplitOptions.RemoveEmptyEntries);
                var parent = cmdArgs[0].Trim();

                if (cmdArgs.Length == 1)
                {
                    if (!graph.ContainsKey(parent))
                        graph[parent] = new List<string>();
                }
                else
                {
                    var children = cmdArgs[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(str => str.Trim()).ToArray();

                    if (!graph.ContainsKey(parent))
                        graph[parent] = new List<string>();

                    graph[parent].AddRange(children);
                }
            }

            foreach (var parent in graph.Keys)
            {
                DFS(parent);
            }

            Console.WriteLine(string.Join(" ", story.Reverse()));
        }

        private static void DFS(string parent)
        {
            if (story.Contains(parent))
                return;

            foreach (var child in graph[parent])
            {
                DFS(child);
            }

            story.Add(parent);
        }
    }
}
