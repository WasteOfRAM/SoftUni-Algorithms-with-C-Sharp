using System;
using System.Collections.Generic;

namespace P06.Word_Cruncher
{
    internal class Program
    {
        private static string[] words;
        private static string targetWord;
        private static Dictionary<int, List<string>> wordsByIndex;
        private static Dictionary<string, int> wordsByCount;
        private static LinkedList<string> usedWords;

        static void Main()
        {
            words = Console.ReadLine().Split(", ");
            targetWord = Console.ReadLine();
            wordsByIndex = new Dictionary<int, List<string>>();
            wordsByCount = new Dictionary<string, int>();
            usedWords = new LinkedList<string>();

            foreach (var word in words)
            {
                int index = targetWord.IndexOf(word);

                if (index == -1)
                    continue;

                if (wordsByCount.ContainsKey(word))
                {
                    wordsByCount[word]++;
                    continue;
                }

                wordsByCount[word] = 1;

                while (index != -1)
                {
                    if (!wordsByIndex.ContainsKey(index))
                        wordsByIndex[index] = new List<string>();

                    wordsByIndex[index].Add(word);

                    index = targetWord.IndexOf(word, index + 1);
                }
            }

            GenSolutions(0);
        }

        private static void GenSolutions(int index)
        {
            if(index == targetWord.Length)
            {
                Console.WriteLine(string.Join(" ", usedWords));
                return;
            }

            if (!wordsByIndex.ContainsKey(index))
                return;

            foreach (var word in wordsByIndex[index])
            {
                if (wordsByCount[word] == 0)
                    continue;

                wordsByCount[word]--;
                usedWords.AddLast(word);

                GenSolutions(index + word.Length);

                wordsByCount[word]++;
                usedWords.RemoveLast();
            }
        }
    }
}
