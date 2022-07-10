using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Dividing_Presents
{
    internal class Program
    {
        static void Main()
        {
            int[] presents = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int presentsTotalValue = presents.Sum();

            var posibleSums = GetPosibleSums(presents);

            var alanSum = presentsTotalValue / 2;

            while (true)
            {
                if (posibleSums.ContainsKey(alanSum))
                {
                    var alanTakes = Subset(posibleSums, alanSum);

                    var bobSum = presentsTotalValue - alanSum;
                    Console.WriteLine($"Difference: {bobSum - alanSum}");
                    Console.WriteLine($"Alan:{alanSum} Bob:{bobSum}");
                    Console.WriteLine($"Alan takes: {string.Join(" ", alanTakes)}");
                    Console.WriteLine($"Bob takes the rest.");
                    break;
                }

                alanSum -= 1;
            }
        }

        private static List<int> Subset(IDictionary<int, int> posibleSums, int target)
        {
            var subset = new List<int>();

            while (target != 0)
            {
                var sum = posibleSums[target];
                subset.Add(sum);
                target -= sum;
            }

            return subset;
        }

        private static IDictionary<int, int> GetPosibleSums(int[] nums)
        {
            var posibleSums = new Dictionary<int, int> { { 0, 0 } };

            foreach (var num in nums)
            {
                var newSums = new Dictionary<int, int>();

                foreach (var sum in posibleSums.Keys)
                {
                    var newSum = num + sum;
                    if (!posibleSums.ContainsKey(newSum))
                        newSums[newSum] = num;
                }

                foreach (var sum in newSums)
                {
                    posibleSums.Add(sum.Key, sum.Value);
                }
            }

            return posibleSums;
        }
    }
}
