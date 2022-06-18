using System;
using System.Linq;

namespace P01.Recursive_Array_Sum
{
    internal class Program
    {
        static void Main()
        {
            //Note: In practice, this recursion should not be used here (instead use an iterative solution), this is just an exercise.

            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Console.WriteLine(GetSum(arr, 0));
        }

        private static int GetSum(int[] arr, int index)
        {
            if (index >= arr.Length)
                return 0;

            return arr[index] + GetSum(arr, index + 1);
        }
    }
}
