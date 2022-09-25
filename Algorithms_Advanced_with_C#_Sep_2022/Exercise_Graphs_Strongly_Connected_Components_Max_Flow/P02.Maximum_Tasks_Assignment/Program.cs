namespace P02.Maximum_Tasks_Assignment
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private static bool[,] graph;
        private static int[] parent;

        static void Main()
        {
            var people = int.Parse(Console.ReadLine());
            var tasks = int.Parse(Console.ReadLine());

            var nodes = people + tasks + 2;

            graph = new bool[nodes, nodes];

            parent = new int[nodes];
            Array.Fill(parent, -1);

            for (int person = 1; person <= people; person++)
            {
                graph[0, person] = true;
            }

            for (int task = people + 1; task <= people + tasks; task++)
            {
                graph[task, nodes - 1] = true;
            }

            for (int person = 1; person <= people; person++)
            {
                var personTasks = Console.ReadLine();

                for (int task = 0; task < personTasks.Length; task++)
                {
                    if (personTasks[task] == 'Y')
                        graph[person, people + task + 1] = true;
                }
            }

            var source = 0;
            var target = nodes - 1;

            while (BFS(source, target))
            {
                var node = target;

                while (parent[node] != -1)
                {
                    var prev = parent[node];
                    graph[prev, node] = false;
                    graph[node, prev] = true;

                    node = prev;
                }
            }

            for (int task = people + 1; task <= people + tasks; task++)
            {
                for (int index = 0; index < graph.GetLength(1); index++)
                {
                    if (graph[task, index])
                    {
                        Console.WriteLine($"{(char)(64 + index)}-{task - people}");
                    }
                }
            }
        }

        private static bool BFS(int source, int target)
        {
            var visited = new bool[graph.GetLength(0)];
            var queue = new Queue<int>();

            visited[source] = true;
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                for (int child = 0; child < graph.GetLength(1); child++)
                {
                    if (!visited[child] && graph[node, child])
                    {
                        parent[child] = node;
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }

            return visited[target];
        }
    }
}