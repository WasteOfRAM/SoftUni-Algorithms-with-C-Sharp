using System;

namespace P01.Binomial_Coefficients
{
    internal class Program
    {
        private static long[,] mem; 

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            mem = new long[n + 1, k + 1];
            mem[0, 0] = 1;

            long binomialCoefficient = BinomialCoefficient(n, k);

            Console.WriteLine(binomialCoefficient);
        }

        private static long BinomialCoefficient(int n, int k)
        {
            if (mem[n, k] != 0)
                return mem[n, k];

            if (k == 0 || k == n)
            {
                mem[n, k] = 1;
                return mem[n, k];
            }

            mem[n, k] = BinomialCoefficient(n - 1, k - 1) + BinomialCoefficient(n - 1, k);

            return mem[n, k];
        }
    }
}
