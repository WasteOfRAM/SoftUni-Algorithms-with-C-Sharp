using System;
using System.Collections.Generic;

namespace P01.Two_Minutes_to_Midnight
{
    public class Program
    {
        private static Dictionary<string, ulong> cache;
        static void Main()
        {
            cache = new Dictionary<string, ulong>();

            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            ulong binomialCoefficient = GetBinomialCoefficient(n, k);

            Console.WriteLine(binomialCoefficient);
        }

        private static ulong GetBinomialCoefficient(int row, int col)
        {
            string cacheKey = $"{row} {col}";

            if (col == 0 || col == row)
                return 1;

            if (cache.ContainsKey(cacheKey))
                return cache[cacheKey];

            ulong result = GetBinomialCoefficient(row - 1, col - 1) + GetBinomialCoefficient(row - 1, col);
            cache[cacheKey] = result;

            return result;
        }
    }
}
