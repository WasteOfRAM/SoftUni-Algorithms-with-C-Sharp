using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Bank_Robbery
{
    internal class Program
    {
        static void Main()
        {
            var loot = Console.ReadLine().Split().Select(int.Parse).ToList();
            int evenSplit = loot.Sum() / 2;

            var posibleSplits = GetBoxes(loot);

            var lootPileOne = GetSubset(posibleSplits, evenSplit);
            var lootPileTwo = new List<int>(loot);

            foreach (var box in lootPileOne)
            {
                lootPileTwo.Remove(box);
            }

            Console.WriteLine(string.Join(" ", lootPileOne.OrderBy(i => i)));
            Console.WriteLine(string.Join(" ", lootPileTwo.OrderBy(i => i)));
        }

        private static List<int> GetSubset(Dictionary<int, int> boxes, int evenSplit)
        {
            var subset = new List<int>();

            while (evenSplit != 0)
            {
                var sum = boxes[evenSplit];
                subset.Add(sum);
                evenSplit -= sum;
            }

            return subset;
        }

        private static Dictionary<int, int> GetBoxes(List<int> loot)
        {
            var posibleSums = new Dictionary<int, int> { { 0, 0 } };

            foreach (var num in loot)
            {
                var newSums = new Dictionary<int, int>();

                foreach (var sum in posibleSums.Keys)
                {
                    var newSum = num + sum;
                    if(!posibleSums.ContainsKey(newSum))
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
