namespace P01.Rod_Cutting
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private static int[] bestPrices;
        private static int[] combo;

        static void Main()
        {
            var prices = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var rodLength = int.Parse(Console.ReadLine());

            bestPrices = new int[prices.Length];
            combo = new int[prices.Length];

            var bestPrice = CutRod(rodLength, prices);

            var rodPices = new List<int>();
            while (rodLength != 0)
            {
                rodPices.Add(combo[rodLength]);
                rodLength -= combo[rodLength];
            }

            Console.WriteLine(bestPrice);
            Console.WriteLine(string.Join(" ", rodPices));
        }

        private static int CutRod(int rodLength, int[] prices)
        {
            if (rodLength == 0) return 0;

            if (bestPrices[rodLength] != 0)
                return bestPrices[rodLength];

            var bestPrice = prices[rodLength];
            var bestCombo = rodLength;

            for (int i = 1; i < rodLength; i++)
            {
                var price = prices[i] + CutRod(rodLength - i, prices);
                if(price > bestPrice)
                {
                    bestPrice = price;
                    bestCombo = i;
                }
            }

            bestPrices[rodLength] = bestPrice;
            combo[rodLength] = bestCombo;

            return bestPrice;
        }
    }
}