namespace P03.Longest_String_Chain
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main()
        {
            var words = Console.ReadLine().Split();

            var bestLen = new int[words.Length];
            var parent = new int[words.Length];
            var maxLen = 0;
            var lastIdx = -1;

            for (int current = 0; current < words.Length; current++)
            {
                var currentStr = words[current];
                var currentBestLen = 1;
                var currntParent = -1;

                for (int prev = current - 1; prev >= 0; prev--)
                {
                    var prevStr = words[prev];
                    var prevLen = bestLen[prev];

                    if (currentStr.Length > prevStr.Length && prevLen + 1 >= currentBestLen)
                    {
                        currentBestLen = prevLen + 1;
                        currntParent = prev;
                    }
                }

                bestLen[current] = currentBestLen;
                parent[current] = currntParent;

                if (currentBestLen > maxLen)
                {
                    maxLen= currentBestLen;
                    lastIdx = current;
                }
            }

            var chain = new Stack<string>();

            while (lastIdx != -1)
            {
                var str = words[lastIdx];
                chain.Push(str);
                lastIdx = parent[lastIdx];
            }

            Console.WriteLine(string.Join(" ", chain));
        }
    }
}