using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Climbing
{
    internal class Program
    {
        private static int[,] building;
        private static int[,] dpMatrix;

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            building = MatrixFill(rows, cols);
            dpMatrix = DPMatrix(rows, cols);

            var path = new Queue<int>();

            int row = rows - 1;
            int col = cols -1;

            while (row > 0 && col > 0)
            {
                path.Enqueue(building[row, col]);

                int upper = dpMatrix[row - 1, col];
                int left = dpMatrix[row, col - 1];

                if(upper > left)
                    row--;
                else
                    col--;
            }

            while (row > 0)
            {
                path.Enqueue(building[row, col]);
                row--;
            }

            while (col > 0)
            {
                path.Enqueue(building[row, col]);
                col--;
            }

            path.Enqueue(building[row, col]);

            Console.WriteLine(dpMatrix[rows - 1, cols - 1]);
            Console.WriteLine(string.Join(" ", path));
        }

        private static int[,] DPMatrix(int rows, int cols)
        {
            var result = new int[rows, cols];

            result[0,0] = building[0,0];

            for (int col = 1; col < result.GetLength(1); col++)
            {
                result[0, col] = result[0, col - 1] + building[0, col];
            }

            for (int row = 1; row < result.GetLength(0); row++)
            {
                result[row, 0] = result[row - 1, 0] + building[row, 0];
            }

            for (int row = 1; row < result.GetLength(0); row++)
            {
                for (int col = 1; col < result.GetLength(1); col++)
                {
                    int upper = building[row, col] + result[row - 1, col];
                    int left = building[row, col] + result[row, col - 1];

                    result[row, col] = Math.Max(upper, left);
                }
            }

            return result;
        }

        private static int[,] MatrixFill(int rows, int cols)
        {
            int[,] result = new int[rows, cols];

            for (int row = 0; row < result.GetLength(0); row++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < result.GetLength(1); col++)
                {
                    result[row, col] = line[col];
                }
            }

            return result;
        }
    }
}
