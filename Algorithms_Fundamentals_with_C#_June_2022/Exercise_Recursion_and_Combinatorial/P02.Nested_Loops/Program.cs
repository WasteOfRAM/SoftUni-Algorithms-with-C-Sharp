using System;

namespace P02.Nested_Loops
{
    internal class Program
    {
        private static int[] elements;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            elements = new int[n];

            Variations(0);
        }

        private static void Variations(int index)
        {
            if(index == elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            for (int i = 1; i <= elements.Length; i++)
            {
                elements[index] = i;
                Variations(index + 1);
            }
        }
    }
}
