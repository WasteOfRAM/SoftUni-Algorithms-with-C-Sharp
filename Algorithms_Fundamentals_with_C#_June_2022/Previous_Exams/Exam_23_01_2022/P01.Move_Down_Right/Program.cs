using System;

namespace P01.Move_Down_Right
{
    internal class Program
    {
        private static ulong[][] dpMatrix;

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            dpMatrix = new ulong[rows][];

            for (int i = 0; i < dpMatrix.Length; i++)
            {
                dpMatrix[i] = new ulong[cols];
            }

            for (int row = 0; row < dpMatrix.Length; row++)
            {
                dpMatrix[row][0] = 1;
            }

            for (int col = 0; col < dpMatrix[0].Length; col++)
            {
                dpMatrix[0][col] = 1;
            }

            for (int row = 1; row < dpMatrix.Length; row++)
            {
                for (int col = 1; col < dpMatrix[row].Length; col++)
                {
                    dpMatrix[row][col] = dpMatrix[row - 1][col] + dpMatrix[row][col - 1];
                }
            }

            Console.WriteLine(dpMatrix[^1][^1]);
        }

        
    }
}
