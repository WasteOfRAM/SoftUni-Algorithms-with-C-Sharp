using System;
using System.Collections.Generic;

namespace Subset_Sum_With_Repetition
{
    internal class Program
    {
        static void Main()
        {
            var nums = new[] { 3, 5, 2 };
            var target = 17;

            bool[] posibleSums = PosibleSums(nums, target);

            var subset = FindSubset(nums, target, posibleSums);

            Console.WriteLine(string.Join(" ", subset));
        }

        private static IList<int> FindSubset(int[] nums, int target, bool[] posibleSums)
        {
            var subset = new List<int>();

            while (target > 0)
            {
                foreach (var num in nums)
                {
                    var newSum = target - num;

                    if(newSum >= 0 && posibleSums[newSum])
                    {
                        target = newSum;
                        subset.Add(num);
                    }
                }
            }

            return subset;
        }

        private static bool[] PosibleSums(int[] nums, int target)
        {
            var posibleSums = new bool[target + 1];
            posibleSums[0] = true;

            for (int sum = 0; sum < posibleSums.Length; sum++)
            {
                if (!posibleSums[sum])
                    continue;

                foreach (var num in nums)
                {
                    var newSum = sum + num;
                    if (newSum <= target)
                        posibleSums[newSum] = true;
                }
            }

            return posibleSums;
        }
    }
}
