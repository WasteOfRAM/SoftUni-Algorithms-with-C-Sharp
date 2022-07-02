using System;
using System.Collections.Generic;

namespace P02.Areas_in_Matrix
{
    internal class Program
    {
        private static char[,] graph;
        private static SortedDictionary<char, int> areas;
        private static bool[,] visited;

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int totalAreas = 0;

            graph = new char[rows, cols];
            areas = new SortedDictionary<char, int>();
            visited = new bool[rows, cols];

            for (int row = 0; row < graph.GetLength(0); row++)
            {
                var line = Console.ReadLine();

                for (int col = 0; col < graph.GetLength(1); col++)
                {
                    graph[row, col] = line[col];
                }
            }

            for (int startRow = 0; startRow < graph.GetLength(0); startRow++)
            {
                for (int startCol = 0; startCol < graph.GetLength(1); startCol++)
                {
                    char areaType = graph[startRow, startCol];

                    if (!visited[startRow, startCol])
                    {
                        DFS(startRow, startCol, areaType);

                        if (!areas.ContainsKey(areaType))
                            areas[areaType] = 0;

                        areas[areaType]++;

                        totalAreas++;
                    }

                }
            }

            Console.WriteLine($"Areas: {totalAreas}");
            foreach (var (k, v) in areas)
            {
                Console.WriteLine($"Letter '{k}' -> {v}");
            }
        }

        private static void DFS(int row, int col, char areaType)
        {
            if (row < 0 || row >= graph.GetLength(0) || col < 0 || col >= graph.GetLength(1))
                return;

            if (graph[row, col] != areaType)
                return;

            if (visited[row, col])
                return;

            visited[row, col] = true;

            DFS(row, col - 1, areaType);
            DFS(row, col + 1, areaType);
            DFS(row - 1, col, areaType);
            DFS(row + 1, col, areaType);
        }
    }
}
