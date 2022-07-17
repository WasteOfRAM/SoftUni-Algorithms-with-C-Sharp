using System;

namespace P01.TBC
{
    internal class Program
    {
        private static char[,] city;
        private static bool[,] visited;

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            const char tunel = 't';
            int tunelsCount = 0;

            city = MatrixFill(rows, cols);
            visited = new bool[rows, cols];

            for (int row = 0; row < city.GetLength(0); row++)
            {
                for (int col = 0; col < city.GetLength(1); col++)
                {
                    if (city[row, col] == tunel && !visited[row, col])
                    {
                        DFSTunelFinder(row, col, tunel);

                        tunelsCount++;
                    }

                }
            }

            Console.WriteLine(tunelsCount);
        }

        private static void DFSTunelFinder(int row, int col, char tunel)
        {
            if (row < 0 || row >= city.GetLength(0) || col < 0 || col >= city.GetLength(1))
                return;

            if (visited[row, col])
                return;

            visited[row, col] = true;

            if (city[row, col] != tunel)
                return;


            DFSTunelFinder(row - 1, col, tunel);
            DFSTunelFinder(row + 1, col, tunel);
            DFSTunelFinder(row, col - 1, tunel);
            DFSTunelFinder(row, col + 1, tunel);
            DFSTunelFinder(row - 1, col - 1, tunel);
            DFSTunelFinder(row + 1, col + 1, tunel);
            DFSTunelFinder(row - 1, col + 1, tunel);
            DFSTunelFinder(row + 1, col - 1, tunel);
        }

        private static char[,] MatrixFill(int rows, int cols)
        {
            char[,] result = new char[rows, cols];

            for (int row = 0; row < result.GetLength(0); row++)
            {
                var line = Console.ReadLine();
                for (int col = 0; col < result.GetLength(1); col++)
                {
                    result[row, col] = line[col];
                }
            }

            return result;
        }
    }
}
