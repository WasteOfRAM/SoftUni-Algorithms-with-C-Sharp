using System;

namespace P04._Recursive_Factorial
{
    internal class Program
    {
        static void Main()
        {
            //NOTE: In practice, this recursion should not be used here (instead use an iterative solution).

            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(n));
        }

        private static int Factorial(int number)
        {
            if (number == 0)
                return 1;



            return number * Factorial(number - 1);
        }
    }
}
