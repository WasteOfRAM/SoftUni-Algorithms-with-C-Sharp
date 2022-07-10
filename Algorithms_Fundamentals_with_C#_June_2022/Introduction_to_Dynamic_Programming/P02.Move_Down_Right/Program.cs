using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Move_Down_Right
{
    internal class Program
    {
        static void Main()
        {
            int numRows = int.Parse(Console.ReadLine());
            int numCols = int.Parse(Console.ReadLine());

            int[,] matrix = MatrixFill(numRows, numCols);

            int[,] dpMatrix = DPMatrix(matrix);

            int row = numRows - 1;
            int col = numCols - 1;

            var path = new Stack<string>();

            while (row > 0 && col > 0)
            {
                path.Push($"[{row}, {col}]");

                int upper = dpMatrix[row - 1, col];
                int left = dpMatrix[row, col -1];

                if (upper > left)
                {
                    row -= 1;
                }
                else
                {
                    col -= 1;
                }
            }

            while (row > 0)
            {
                path.Push($"[{row}, {col}]");
                row -= 1;
            }

            while (col > 0)
            {
                path.Push($"[{row}, {col}]");
                col -= 1;
            }

            path.Push($"[{row}, {col}]");
            Console.WriteLine(string.Join(" ", path));
        }

        private static int[,] DPMatrix(int[,] matrix)
        {
            var dp = new int[matrix.GetLength(0), matrix.GetLength(1)];

            dp[0, 0] = matrix[0, 0];

            for (int col = 1; col < dp.GetLength(1); col++)
            {
                dp[0, col] = dp[0, col - 1] + matrix[0, col];
            }

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                dp[row, 0] = dp[row - 1, 0] + matrix[row, 0];
            }

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                for (int col = 1; col < dp.GetLength(1); col++)
                {
                    int upper = matrix[row, col] + dp[row - 1, col];
                    int left = matrix[row, col] + dp[row, col - 1];

                    dp[row, col] = Math.Max(upper, left);
                }
            }

            return dp;
        }

        private static int[,] MatrixFill(int numRows, int numCols)
        {
            var matrix = new int[numRows, numCols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            return matrix;
        }
    }
}
