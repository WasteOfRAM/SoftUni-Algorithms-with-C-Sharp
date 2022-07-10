using System;
using System.Collections.Generic;

namespace P03.Longest_Common_Subsequence
{
    internal class Program
    {
        static void Main()
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            var lcs = new int[str1.Length + 1, str2.Length + 1];

            for (int row = 1; row < lcs.GetLength(0); row++)
            {
                for (int col = 1; col < lcs.GetLength(1); col++)
                {
                    if (str1[row - 1] == str2[col - 1])
                        lcs[row, col] = lcs[row - 1, col - 1] + 1;
                    else
                        lcs[row, col] = Math.Max(lcs[row, col - 1], lcs[row - 1, col]);
                }
            }

            Console.WriteLine(lcs[str1.Length, str2.Length]);

            //var sequence = new Stack<char>();

            //var rows = lcs.GetLength(0) - 1;
            //var cols = lcs.GetLength(1) - 1;

            //while (rows > 0 && cols > 0)
            //{
            //    if (str1[rows - 1] == str2[cols - 1] && lcs[rows, cols] == lcs[rows - 1, cols -1] + 1)
            //    {
            //        sequence.Push(str1[rows - 1]);

            //        rows -= 1;
            //        cols -= 1;
            //    }
            //    else if (lcs[rows - 1, cols] > lcs[rows, cols - 1])
            //    {
            //        rows -= 1;
            //    }
            //    else
            //    {
            //        cols -= 1;
            //    }
            //}

            //Console.WriteLine(string.Join("", sequence));
        }
    }
}
