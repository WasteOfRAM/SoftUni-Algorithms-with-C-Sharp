using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.Sum_of_Coins
{
    internal class Program
    {
        public static void Main()
        {
            var availableCoins = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).OrderByDescending(x => x));
            var targetSum = int.Parse(Console.ReadLine());
            int coinsTaken = 0;

            var coinsCount = new Dictionary<int, int>();

            while (targetSum > 0 && availableCoins.Count  > 0)
            {
                int currentCoin = availableCoins.Dequeue();
                int count = targetSum / currentCoin;

                if (count == 0)
                    continue;

                coinsCount[currentCoin] = count;
                coinsTaken += count;

                targetSum %= currentCoin;
            }


            if(targetSum == 0)
            {
                Console.WriteLine($"Number of coins to take: {coinsTaken}");

                foreach (var coin in coinsCount)
                {
                    Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
                }
            }
            else
            {
                Console.WriteLine("Error");
            }


        }

        
    }
}
