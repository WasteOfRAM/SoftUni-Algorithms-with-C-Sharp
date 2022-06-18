﻿using System;

namespace P03._Generating_0_1_Vectors
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            Gen01(arr, 0);
        }

        private static void Gen01(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(string.Empty, arr));
                return;
            }
            
            for (int i = 0; i < 2; i++)
            {
                arr[index] = i;
                Gen01(arr, index + 1);
            }
        }
    }
}
