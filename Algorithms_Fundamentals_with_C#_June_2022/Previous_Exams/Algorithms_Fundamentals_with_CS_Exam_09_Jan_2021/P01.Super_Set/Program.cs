using System;
using System.Linq;

namespace P01.Super_Set
{
    internal class Program
    {
        private static int[] elements;
 
        static void Main()
        {
            elements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            for (int combinationsLenght = 1; combinationsLenght <= elements.Length; combinationsLenght++)
            {
                var combinations = new int[combinationsLenght];
                Subset(0, 0, combinations);
            }
        }

        private static void Subset(int index, int start, int[] combinations)
        {
            if(index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                combinations[index] = elements[i];
                Subset(index + 1, i + 1, combinations);
            }
        }
    }
}
