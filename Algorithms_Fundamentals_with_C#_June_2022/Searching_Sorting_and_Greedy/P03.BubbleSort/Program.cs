using System;
using System.Linq;

namespace P03.BubbleSort
{
    internal class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            BubbleSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void BubbleSort(int[] numbers)
        {
            bool isSorted = false;
            int i = 0;

            while (!isSorted)
            {
                isSorted = true;

                for (int j = 1; j < numbers.Length - i; j++)
                {
                    if (numbers[j - 1] > numbers[j])
                    {
                        isSorted = false;
                        Swap(numbers, j - 1, j);
                    }
                }

                i++;
            }
        }

        private static void Swap(int[] arr, int first, int second)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }
}
