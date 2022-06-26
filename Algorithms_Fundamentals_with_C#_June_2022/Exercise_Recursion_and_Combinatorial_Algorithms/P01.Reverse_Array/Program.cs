using System;

namespace P01.Reverse_Array
{
    internal class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine().Split();

            ArrayReverse(0, arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void ArrayReverse<T>(int index, params T[] arr)
        {
            if(arr.Length / 2 == index)
                return;

            var temp = arr[index];
            arr[index] = arr[arr.Length - 1 - index];
            arr[arr.Length - 1 - index] = temp;

            ArrayReverse(index + 1, arr);
        }
    }
}
