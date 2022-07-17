using System;
using System.Collections.Generic;

namespace P03.Strings_Mashup
{
    internal class Program
    {
        private static char[] str;
        private static HashSet<string> permutations;

        static void Main()
        {
            str = Console.ReadLine().ToUpper().ToCharArray();
            permutations = new HashSet<string>();

            Permutation(0);

            foreach (var set in permutations)
            {
                Console.WriteLine(set);
            }
        }

        private static void Permutation(int index)
        {

            if (index >= str.Length)
            {
                permutations.Add(string.Join(string.Empty, str));

                return;
            }

            Permutation(index + 1);

            str[index] = char.ToLower(str[index]);

            Permutation(index + 1);

            str[index] = char.ToUpper(str[index]);
        }
    }
}


// This solution works and it gives 100 points in the judge system. I dont know if its a good one becouse I am realy unhappy with it.
// Cant find another for now maybe will try it again but I'm done for now.