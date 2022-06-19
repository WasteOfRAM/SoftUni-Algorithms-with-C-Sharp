using System;

namespace P07.N_Choose_K_Count
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine(Binomial(n, k));
        }

        //Pascal's Triangel to find posible combinations with n posible elements in k posible positions

        private static long Binomial(int row, int col)
        {
            if (row <= 1 || col == 0 || col == row)
                return 1;

            return Binomial(row - 1, col) + Binomial(row - 1, col - 1);
        }
    }
}
