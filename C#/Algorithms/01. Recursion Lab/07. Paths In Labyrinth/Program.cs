namespace _07._Paths_In_Labyrinth
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        static List<char> path = new List<char>();
        static int[,] labirinth;

        public static void Main(string[] args)
        {
            labirinth = ReadLabirinth();

            FindPaths(0, 0, 'S');
        }

        private static void FindPaths(int row, int col, char direction)
        {
            if (!IsInRange(row, col))
            {
                return;
            }

            path.Add(direction);

            if (labirinth[row, col] == 'e')
            {
                Console.WriteLine(string.Join(string.Empty, path.Skip(1)));
            }
            else
            {
                labirinth[row, col] = '*';

                FindPaths(row + 1, col, 'D');
                FindPaths(row - 1, col, 'U');
                FindPaths(row, col + 1, 'R');
                FindPaths(row, col - 1, 'L');

                labirinth[row, col] = '-';
            }

            path.RemoveAt(path.Count - 1);
        }

        private static bool IsInRange(int row, int col)
        {
            if (row < 0
                || col < 0
                || row >= labirinth.GetLength(0)
                || col >= labirinth.GetLength(1)
                || labirinth[row, col] == '*')
            {
                return false;
            }

            return true;
        }

        private static int[,] ReadLabirinth()
        {
            int rowsCount = int.Parse(Console.ReadLine());
            int colsCount = int.Parse(Console.ReadLine());

            int[,] labyrinth = new int[rowsCount, colsCount];

            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    labyrinth[row, col] = currentRow[col];
                }
            }

            return labyrinth;
        }
    }
}
