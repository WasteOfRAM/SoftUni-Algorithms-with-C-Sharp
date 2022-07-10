using System;

namespace P07.Minimum_Edit_Distance
{
    internal class Program
    {
        static void Main()
        {
            int replaceCost = int.Parse(Console.ReadLine());
            int incertCost = int.Parse(Console.ReadLine());
            int deleteCost = int.Parse(Console.ReadLine());

            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            var dp = new int[str1.Length + 1, str2.Length + 1];

            for (int col = 1; col < dp.GetLength(1); col++)
            {
                dp[0, col] = dp[0, col - 1] + incertCost;
            }

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                dp[row, 0] = dp[row - 1, 0] + deleteCost;
            }

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                for (int col = 1; col < dp.GetLength(1); col++)
                {
                    if (str1[row - 1] == str2[col - 1])
                        dp[row, col] = dp[row - 1, col - 1];
                    else
                    {
                        int replace = dp[row - 1, col - 1] + replaceCost;
                        int incert = dp[row, col - 1] + incertCost;
                        int delete = dp[row - 1, col] + deleteCost;

                        dp[row, col] = Math.Min(Math.Min(replace, incert), delete);
                    }
                }
            }

            Console.WriteLine($"Minimum edit distance: {dp[str1.Length, str2.Length]}");
        }
    }
}
