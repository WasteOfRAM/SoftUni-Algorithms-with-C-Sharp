using System;

namespace P04.Variations_with_Repetition
{
    internal class Program
    {
        private static string[] elements;
        private static string[] variations;

        static void Main()
        {
            elements = Console.ReadLine().Split();
            int k = int.Parse(Console.ReadLine());
            variations = new string[k];

            VariationsWithRepetition(0);
        }

        private static void VariationsWithRepetition(int index)
        {
            if(index >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                variations[index] = elements[i];
                VariationsWithRepetition(index + 1);
            }
        }
    }
}
