using System;
using System.Linq;

namespace P02.Selection_Sort
{
    internal class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            SelectionSort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void SelectionSort(int[] arr)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[min] > arr[j])
                        min = j;
                }
                Swap(arr, i, min);
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
