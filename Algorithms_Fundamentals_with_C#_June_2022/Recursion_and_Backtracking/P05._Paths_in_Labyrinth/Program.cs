using System;
using System.Collections.Generic;

namespace P05._Paths_in_Labyrinth
{
    public class Program
    {
        static void Main()
        {
            char[,] labyrinth = ReadMatrix();


            PathFinder(labyrinth, 0, 0, new List<string>(), string.Empty);
        }

        private static void PathFinder(char[,] labyrinth, int row, int col, List<string> directions, string directoion)
        {
            // Chack index validity
            if (!IndexValidation(labyrinth, row, col))
                return;

            // If the move is blocked by wall '*' or it is visited 'v' go back
            if (labyrinth[row, col] == 'v' || labyrinth[row, col] == '*')
                return;

            // Ading the direction we moved to
            directions.Add(directoion);

            // If the exit is found print the path and remove last move before going back 
            if (labyrinth[row, col] == 'e')
            {
                Console.WriteLine(string.Join(string.Empty, directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            // Marking visited path
            labyrinth[row, col] = 'v';

            PathFinder(labyrinth, row - 1, col, directions, "U");
            PathFinder(labyrinth, row + 1, col, directions, "D");
            PathFinder(labyrinth, row, col - 1, directions, "L");
            PathFinder(labyrinth, row, col + 1, directions, "R");

            // Unmarking on the way back
            labyrinth[row, col] = '-';

            // Remove last move before going back
            directions.RemoveAt(directions.Count - 1);
        }

        private static char[,] ReadMatrix()
        {
            int matrixRows = int.Parse(Console.ReadLine());
            int matrixColumns = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixRows, matrixColumns];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            return matrix;
        }

        private static bool IndexValidation(char[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
                return true;

            return false;
        }


    }
}
