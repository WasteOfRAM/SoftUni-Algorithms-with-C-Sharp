using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Connected_Areas
{
    internal class Program
    {
        private static char[,] matrix;
        private static List<Area> areasFound;
        private static int currentSize;
        private static char visited;

        static void Main()
        {
            areasFound = new List<Area>();
            visited = 'v';

            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            matrix = new char[rows, columns];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var line = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    currentSize = 0;

                    FindArea(row, col);

                    if (currentSize > 0)
                        areasFound.Add(new Area { Row = row, Col = col, Size = currentSize });
                }
            }

            Console.WriteLine($"Total areas found: {areasFound.Count}");

            int index = 1;
            foreach (var area in areasFound.OrderByDescending(a => a.Size).ThenBy(a => a.Row).ThenBy(a => a.Col))
            {
                Console.WriteLine($"Area #{index++} at ({area.Row}, {area.Col}), size: {area.Size}");
            }
        }

        private static void FindArea(int row, int col)
        {
            if (!ValidIndex(row, col) || matrix[row, col] == '*' || matrix[row, col] == visited)
            {

                return;
            }

            currentSize++;
            matrix[row, col] = visited;

            FindArea(row - 1, col);
            FindArea(row + 1, col);
            FindArea(row, col - 1);
            FindArea(row, col + 1);
        }

        private static bool ValidIndex(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }

    class Area
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Size { get; set; }
    }
}
