using System;
using System.Linq;

namespace P02.Socks
{
    internal class Program
    {
        private static int[,] lcsTable;
        static void Main()
        {
            int[] firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            lcsTable = new int[firstLine.Length + 1, secondLine.Length + 1];

            TableFill(firstLine, secondLine);

            Console.WriteLine(lcsTable[lcsTable.GetLength(0) - 1, lcsTable.GetLength(1) - 1]);
        }

        private static void TableFill(int[] firstLine, int[] secondLine)
        {
            for (int row = 1; row < lcsTable.GetLength(0); row++)
            {
                for (int col = 1; col < lcsTable.GetLength(1); col++)
                {
                    if (firstLine[row - 1] == secondLine[col - 1])
                        lcsTable[row, col] = lcsTable[row - 1, col - 1] + 1;
                    else
                        lcsTable[row, col] = Math.Max(lcsTable[row - 1, col], lcsTable[row, col - 1]);
                }
            }
        }
    }
}
