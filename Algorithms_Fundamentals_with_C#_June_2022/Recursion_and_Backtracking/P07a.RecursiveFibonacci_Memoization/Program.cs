using System;
using System.Collections.Generic;
using System.Numerics;

namespace P07a.RecursiveFibonacci_Memoization
{
    internal class Program
    {
        private static Dictionary<BigInteger, BigInteger> mem = new Dictionary<BigInteger, BigInteger>();

        static void Main(string[] args)
        {
            BigInteger wantedFibNum = BigInteger.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(wantedFibNum));
        }

        private static BigInteger GetFibonacci(BigInteger wantedFibNum)
        {
            if (wantedFibNum <= 1)
                return 1;

            BigInteger fibonacciOneBeffore;
            BigInteger fibonacciTwoBeffore;

            if (mem.ContainsKey(wantedFibNum - 1))
                fibonacciOneBeffore = mem[wantedFibNum - 1];
            else
            {
                mem[wantedFibNum - 1] = GetFibonacci(wantedFibNum - 1);
                fibonacciOneBeffore = mem[wantedFibNum - 1];
            }

            if (mem.ContainsKey(wantedFibNum - 2))
                fibonacciTwoBeffore = mem[wantedFibNum - 2];
            else
            {
                mem[wantedFibNum - 2] = GetFibonacci(wantedFibNum - 2);
                fibonacciTwoBeffore = mem[wantedFibNum - 2];
            }

            mem[wantedFibNum] = fibonacciOneBeffore + fibonacciTwoBeffore;

            return mem[wantedFibNum];
        }
    }
}
