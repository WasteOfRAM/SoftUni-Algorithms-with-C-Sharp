namespace P03.Longest_Increasing_Subsequence
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main()
        {
            var sequence = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            var len = new int[sequence.Length];
            var prev = new int[sequence.Length];

            int maxLen = 0;
            int lastIndex = -1;

            for (int i = 0; i < sequence.Length; i++)
            {
                var bestLength = 1;
                var prevIndex = -1;

                var currentNumber = sequence[i];

                for (int j = i - 1; j >= 0; j--)
                {
                    var previousNumber = sequence[j];

                    if (previousNumber < currentNumber && bestLength <= len[j] + 1)
                    {
                        bestLength = len[j] + 1;
                        prevIndex = j;
                    }
                }

                len[i] = bestLength;
                prev[i] = prevIndex;

                if (bestLength > maxLen)
                {
                    maxLen = bestLength;
                    lastIndex = i;
                }
            }

            var longestSeq = new Stack<int>();

            while (lastIndex != -1)
            {
                longestSeq.Push(sequence[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            Console.WriteLine(string.Join(" ", longestSeq));
        }
    }
}