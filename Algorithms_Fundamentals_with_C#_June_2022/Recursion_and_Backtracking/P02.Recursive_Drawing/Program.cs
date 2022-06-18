using System;

namespace P02.Recursive_Drawing
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Drawing(n);
        }

        private static void Drawing(int n)
        {
            if (n == 0)
                return;

            Console.WriteLine(new string('*', n));

            Drawing(n - 1);

            Console.WriteLine(new string('#', n));
        }
    }
}
