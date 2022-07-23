using System;

namespace P01.Strings_Mashup
{
    internal class Program
    {
        private static char[] elements;
        private static char[] combinations;

        static void Main()
        {
            elements = Console.ReadLine().ToCharArray();
            Array.Sort(elements);

            int stringLenght = int.Parse(Console.ReadLine());
            combinations = new char[stringLenght];

            Combinations(0, 0);

        }

        private static void Combinations(int index, int start)
        {
            if(index >= combinations.Length)
            {
                Console.WriteLine(string.Join("", combinations));
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                combinations[index] = elements[i];
                Combinations(index + 1, i);
            }
        }
    }
}
