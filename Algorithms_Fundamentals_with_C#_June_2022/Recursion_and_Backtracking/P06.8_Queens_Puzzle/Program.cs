using System;
using System.Collections.Generic;

namespace P06._8_Queens_Puzzle
{
    internal class Program
    {
        private static HashSet<int> attakedRow = new HashSet<int>();
        private static HashSet<int> attakedCol = new HashSet<int>();
        private static HashSet<int> attakedLeftDiag = new HashSet<int>();
        private static HashSet<int> attakedRightDiag = new HashSet<int>();

        static void Main()
        {
            bool[,] board = new bool[8, 8];

            PlaceQueen(board, 0);
        }

        private static void PlaceQueen(bool[,] board, int row)
        {
            if(row >= board.GetLength(0))
            {
                MatrixPrint(board);
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (CanBePlaced(row, col))
                {
                    attakedRow.Add(row);
                    attakedCol.Add(col);
                    attakedLeftDiag.Add(col - row);
                    attakedRightDiag.Add(row + col);
                    board[row, col] = true;

                    PlaceQueen(board, row + 1);

                    attakedRow.Remove(row);
                    attakedCol.Remove(col);
                    attakedLeftDiag.Remove(col - row);
                    attakedRightDiag.Remove(row + col);
                    board[row, col] = false;
                }
            }
        }

        private static void MatrixPrint(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if(board[row, col] == false)
                        Console.Write("- ");
                    else
                        Console.Write("* ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static bool CanBePlaced(int row, int col)
        {
            return !attakedRow.Contains(row) &&
                   !attakedCol.Contains(col) &&
                   !attakedLeftDiag.Contains(col - row) &&
                   !attakedRightDiag.Contains(row + col);
        }
    }
}
