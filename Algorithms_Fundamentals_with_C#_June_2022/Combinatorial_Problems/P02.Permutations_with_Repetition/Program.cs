using System;
using System.Collections.Generic;

namespace P02.Permutations_with_Repetition
{
    internal class Program
    {
        private static string[] elements;

        static void Main()
        {
            elements = /*new string[] { "A", "B", "B" };*/ Console.ReadLine().Split();

            Permute(0);
        }

        private static void Permute(int index)
        {
            if(index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Permute(index + 1);

            var swaped = new HashSet<string> { elements[index] };

            for (int i = index + 1; i < elements.Length; i++)
            {
                if (!swaped.Contains(elements[i]))
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);
                    swaped.Add(elements[i]);
                }
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
