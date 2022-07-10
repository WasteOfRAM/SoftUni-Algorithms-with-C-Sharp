using System;
using System.Collections.Generic;

namespace P01.Fibonacci
{
    internal class Program
    {
        private static Dictionary<int, long> mem = new Dictionary<int, long>(); 

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Fibonacci(n));
        }

        private static long Fibonacci(int n)
        {
            if (mem.ContainsKey(n))
                return mem[n];

            if (n == 0)
                return 0;

            if (n == 1)
                return 1;

            long result = Fibonacci(n - 1) + Fibonacci(n - 2);
            mem[n] = result;

            return result;
        }
    }
}
