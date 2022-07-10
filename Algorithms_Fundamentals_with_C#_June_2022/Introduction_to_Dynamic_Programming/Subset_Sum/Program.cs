using System;
using System.Collections.Generic;

namespace Subset_Sum
{
    internal class Program
    {
        static void Main()
        {
            //No repetition

            var nums = new int[] { 3, 5, 1, 4, 2 };
            int target = int.Parse(Console.ReadLine());

            var posibleSums = PosibleSums(nums);

            IList<int> subset = null;

            try
            {
                subset = FindSubset(target, posibleSums);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            Console.WriteLine(string.Join(" ", subset));
        }

        private static IList<int> FindSubset(int target, IDictionary<int, int> posibleSums)
        {
            var subset = new List<int>();

            while (target > 0)
            {
                var lastNum = 0;

                if (posibleSums.ContainsKey(target))
                    lastNum = posibleSums[target];
                else
                    throw new ArgumentException("Sum not posible.");

                subset.Add(lastNum);
                target -= lastNum;
            }

            return subset;
        }

        private static IDictionary<int, int> PosibleSums(int[] nums)
        {
            var posibleSums = new Dictionary<int, int> { { 0, 0 } };

            foreach (var num in nums)
            {
                var newSums = new Dictionary<int, int>();

                foreach (var sum in posibleSums.Keys)
                {
                    var newSum = sum + num;
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
