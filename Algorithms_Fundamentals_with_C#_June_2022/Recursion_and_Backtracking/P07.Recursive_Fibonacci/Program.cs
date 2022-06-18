using System;

namespace P07.Recursive_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wantedFibNum = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(wantedFibNum));
        }

        private static int GetFibonacci(int wantedFibNum)
        {
            if (wantedFibNum <= 1)
                return 1;

            return GetFibonacci(wantedFibNum - 1) + GetFibonacci(wantedFibNum - 2);
        }
    }
}
