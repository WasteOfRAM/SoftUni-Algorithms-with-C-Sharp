using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Time
{
    public class Program
    {
        private static int[][] lscTable;

        static void Main()
        {
            int[] firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();

            lscTable = new int[firstLine.Length + 1][];

            for (int i = 0; i < lscTable.Length; i++)
            {
                lscTable[i] = new int[secondLine.Length + 1];
            }

            TableFill(firstLine, secondLine);

            Stack<int> lsc = GetLSC(firstLine, secondLine);

            int lscLenght = lscTable[^1][^1];


            Console.WriteLine(string.Join(" ", lsc));
            Console.WriteLine(lscLenght);
        }

        private static Stack<int> GetLSC(int[] firstLine, int[] secondLine)
        {
            var result = new Stack<int>();

            int row = firstLine.Length;
            int col = secondLine.Length;

            while (row > 0 && col > 0)
            {
                if (firstLine[row - 1] == secondLine[col - 1])
                {
                    result.Push(firstLine[row - 1]);

                    row--;
                    col--;
                }
                else if (lscTable[row][col -1] >= lscTable[row - 1][col])
                {
                    col--;
                }
                else
                {
                    row--;
                }
            }

            return result;
        }

        private static void TableFill(int[] firstLine, int[] secondLine)
        {
            for (int row = 1; row < lscTable.Length; row++)
            {
                for (int col = 1; col < lscTable[row].Length; col++)
                {
                    if (firstLine[row - 1] == secondLine[col - 1])
                        lscTable[row][col] = lscTable[row - 1][col - 1] + 1;
                    else
                        lscTable[row][col] = Math.Max(lscTable[row - 1][col], lscTable[row][col - 1]);
                }
            }
        }
    }
}
