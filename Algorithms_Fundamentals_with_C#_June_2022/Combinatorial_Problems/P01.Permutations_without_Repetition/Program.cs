using System;

namespace P01.Permutations_without_Repetition
{
    internal class Program
    {
        private static string[] elements;

        static void Main()
        {
            elements = /*new string[] { "A", "B", "C" };*/ Console.ReadLine().Split();

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Permute(index + 1);

            for (int i = index + 1; i < elements.Length; i++)
            {

                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}
