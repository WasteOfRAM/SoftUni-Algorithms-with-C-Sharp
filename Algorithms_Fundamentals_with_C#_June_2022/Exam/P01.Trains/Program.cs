using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Trains
{
    internal class Program
    {
        static void Main()
        {
            double[] arrivalTimes = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] departureTimes = Console.ReadLine().Split().Select(double.Parse).ToArray();

            int timesCount = arrivalTimes.Length;

            Array.Sort(arrivalTimes);
            Array.Sort(departureTimes);

            int platforms = 1;
            int result = 1;
            int i = 1;
            int j = 0;

            while (i < timesCount && j < timesCount)
            {
                if (arrivalTimes[i] < departureTimes[j])
                {
                    platforms++;
                    i++;

                    if (result < platforms)
                    {
                        result = platforms;
                    }
                }
                else
                {
                    platforms--;
                    j++;
                }
            }
            


            Console.WriteLine(result);
        }
    }
}
