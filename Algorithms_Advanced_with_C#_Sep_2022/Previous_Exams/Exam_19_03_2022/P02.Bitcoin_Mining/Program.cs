namespace P02.Bitcoin_Mining
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Transaction
    {
        public string Hash { get; set; }
        public int Size { get; set; }
        public int Fees { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public override string ToString()
        {
            return this.Hash;
        }
    }

    internal class Program
    {

        static void Main()
        {
            var transactions = new List<Transaction>();
            var usedTransactions = new List<Transaction>();

            var blockCapacity = 1000000;

        var pendingTransactions = int.Parse(Console.ReadLine());

            for (int i = 0; i < pendingTransactions; i++)
            {
                var transactionInfo = Console.ReadLine().Split(" ");
                var hash = transactionInfo[0];
                var size = int.Parse(transactionInfo[1]);
                var fees = int.Parse(transactionInfo[2]);
                var from = transactionInfo[3];
                var to = transactionInfo[4];

                transactions.Add(new Transaction { Hash = hash, Size = size, Fees = fees, From = from, To = to });
            }

            var dp = new int[transactions.Count + 1, blockCapacity + 1];
            var selectedTransactions = new bool[transactions.Count + 1, blockCapacity + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                var currentTransaction = transactions[row - 1];
                for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
                {
                    var excluding = dp[row - 1, capacity];
                    if (currentTransaction.Size > capacity)
                    {
                        dp[row, capacity] = excluding;
                        continue;
                    }

                    var including = currentTransaction.Fees + dp[row - 1, capacity - currentTransaction.Size];

                    if (including > excluding)
                    {
                        dp[row, capacity] = including;
                        selectedTransactions[row, capacity] = true;
                    }
                    else
                    {
                        dp[row, capacity] = excluding;
                    }
                }
            }

            for (int row = dp.GetLength(0) - 1; row >= 0; row--)
            {
                if (selectedTransactions[row, blockCapacity])
                {
                    var transaction = transactions[row - 1];
                    usedTransactions.Add(transaction);
                    blockCapacity -= transaction.Size;
                }
            }

            var totalSize = usedTransactions.Sum(t => t.Size);
            var totalFees = usedTransactions.Sum(t => t.Fees);

            Console.WriteLine($"Total Size: {totalSize}");
            Console.WriteLine($"Total Fees: {totalFees}");

            Console.WriteLine(string.Join(Environment.NewLine, usedTransactions));
        }
    }
}