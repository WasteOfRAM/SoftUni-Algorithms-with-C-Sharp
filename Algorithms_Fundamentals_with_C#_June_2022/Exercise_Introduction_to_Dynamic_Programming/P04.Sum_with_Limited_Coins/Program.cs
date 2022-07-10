using System;
using System.Linq;
using System.Collections.Generic;

namespace P04.Sum_with_Limited_Coins
{
    internal class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int target = int.Parse(Console.ReadLine());

            Console.WriteLine(SumsCount(numbers, target));
        }

        private static int SumsCount(int[] numbers, int target)
        {
            int count = 0;

            var sums = new HashSet<int> { 0 };

            foreach (var number in numbers)
            {
                var newSums = new HashSet<int>();

                foreach (var sum in sums)
                {
                    int newSum = sum + number;

                    if (newSum == target)
                        count++;

                    newSums.Add(newSum);
                }

                sums.UnionWith(newSums);
            }

            return count;
        }
    }
}
