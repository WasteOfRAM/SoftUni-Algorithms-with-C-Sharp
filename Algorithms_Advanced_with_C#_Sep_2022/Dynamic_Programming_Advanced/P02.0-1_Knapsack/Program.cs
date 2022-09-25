namespace P02._0_1_Knapsack
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

    internal class Program
    {
        static void Main()
        {
            var bagCapacity = int.Parse(Console.ReadLine());
            var items = new List<Item>();
            var usedItems = new List<Item>();

            string itemsInput;
            while ((itemsInput = Console.ReadLine()) != "end")
            {
                var itemsData = itemsInput.Split(" ");
                var itemName = itemsData[0];
                var itemWeight = int.Parse(itemsData[1]);
                var itemValue = int.Parse(itemsData[2]);

                var item = new Item { Name = itemName, Weight = itemWeight, Value = itemValue };

                items.Add(item);
            }

            var dp = new int[items.Count + 1, bagCapacity + 1];
            var selectedItems = new bool[items.Count + 1, bagCapacity + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                var currentItem = items[row - 1];
                for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
                {
                    var excluding = dp[row - 1, capacity];
                    if (currentItem.Weight > capacity)
                    {
                        dp[row, capacity] = excluding;
                        continue;
                    }

                    var including = currentItem.Value + dp[row - 1, capacity - currentItem.Weight];

                    if (including > excluding)
                    {
                        dp[row, capacity] = including;
                        selectedItems[row, capacity] = true;
                    }
                    else
                    {
                        dp[row, capacity] = excluding;
                    }
                }
            }

            for (int row = dp.GetLength(0) - 1; row >= 0; row--)
            {
                if (selectedItems[row, bagCapacity])
                {
                    var item = items[row - 1];
                    usedItems.Add(item);
                    bagCapacity -= item.Weight;
                }
            }

            var totalWeight = usedItems.Sum(i => i.Weight);
            var totalValue = usedItems.Sum(i => i.Value);

            Console.WriteLine($"Total Weight: {totalWeight}");
            Console.WriteLine($"Total Value: {totalValue}");
            Console.WriteLine(string.Join(Environment.NewLine, usedItems.OrderBy(i => i.Name)));
        }
    }
}