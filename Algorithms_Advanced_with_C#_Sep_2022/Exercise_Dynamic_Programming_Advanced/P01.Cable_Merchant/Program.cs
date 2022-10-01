namespace P01.Cable_Merchant
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        private static List<int> price;
        private static int[] bestPrice;
        static void Main()
        {
            price = new List<int> { 0 };

            price.AddRange(Console.ReadLine().Split().Select(int.Parse));

            bestPrice = new int[price.Count];

            var conectorPrice = int.Parse(Console.ReadLine());

            CutRod(price.Count - 1, conectorPrice);

            Console.WriteLine(string.Join(" ", bestPrice.Skip(1)));
        }

        private static int CutRod(int length, int conectorPrice)
        {
            if (length == 0)
            {
                return 0;
            }

            if(bestPrice[length] != 0)
            {
                return bestPrice[length];
            }

            var currentBestPrice = price[length];

            for (int i = 1; i < length; i++)
            {
                var currentPrice = price[i] + CutRod(length - i, conectorPrice) - 2 * conectorPrice;
                if (currentPrice > currentBestPrice)
                {
                    currentBestPrice = currentPrice;
                }
            }

            bestPrice[length] = currentBestPrice;
            return currentBestPrice;
        }
    }
}