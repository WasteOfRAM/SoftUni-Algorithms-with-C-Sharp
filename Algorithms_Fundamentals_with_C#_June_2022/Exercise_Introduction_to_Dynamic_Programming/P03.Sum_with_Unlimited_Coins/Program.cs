using System;
using System.Linq;

namespace P03.Sum_with_Unlimited_Coins
{
    internal class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int target = int.Parse(Console.ReadLine());

            Console.WriteLine(CountSums(numbers, target));
        }

        private static int CountSums(int[] numbers, int target)
        {
            var sums = new int[target + 1];
            sums[0] = 1;

            foreach (var number in numbers)
            {
                for (int sum = number; sum <= target; sum++)
                {
                    sums[sum] += sums[sum - number];
                }
            }

            return sums[target];
        }
    }
}
