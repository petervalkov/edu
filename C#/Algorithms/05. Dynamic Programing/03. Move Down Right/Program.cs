namespace _03._Move_Down_Right
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static int[,] matrix;
        static int[,] solutions;

        public static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());
            int colsCount = int.Parse(Console.ReadLine());

            InitializeMatrix(rowsCount, colsCount);
            FindSolutions();

            string[] output = FindBestPath();
            Console.WriteLine(string.Join(" ", output));
        }

        private static string[] FindBestPath()
        {
            List<string> path = new List<string>();

            int currentRow = solutions.GetLength(0) - 1;
            int currentCol = solutions.GetLength(1) - 1;

            path.Add($"[{currentRow}, {currentCol}]");

            while (currentRow != 0 || currentCol != 0)
            {
                if (currentRow == 0)
                {
                    path.Add($"[{currentRow}, {--currentCol}]");
                }
                else if (currentCol == 0)
                {
                    path.Add($"[{--currentRow}, {currentCol}]");
                }
                else
                {
                    int pathUp = solutions[currentRow - 1, currentCol];
                    int pathLeft = solutions[currentRow, currentCol - 1];

                    if (pathUp > pathLeft)
                    {
                        path.Add($"[{--currentRow}, {currentCol}]");
                    }
                    else
                    {
                        path.Add($"[{currentRow}, {--currentCol}]");
                    }
                }
            }

            path.Reverse();
            return path.ToArray();
        }

        private static void FindSolutions()
        {
            solutions = new int[matrix.GetLength(0), matrix.GetLength(1)];
            solutions[0, 0] = matrix[0, 0];

            for (int row = 1; row < solutions.GetLength(0); row++)
            {
                solutions[row, 0] = solutions[row - 1, 0] + matrix[row, 0];
            }

            for (int col = 1; col < solutions.GetLength(1); col++)
            {
                solutions[0, col] = solutions[0, col - 1] + matrix[0, col];
            }

            for (int row = 1; row < solutions.GetLength(0); row++)
            {
                for (int col = 1; col < solutions.GetLength(1); col++)
                {
                    int pathUp = matrix[row, col] + solutions[row - 1, col];
                    int pathLeft = matrix[row, col] + solutions[row, col - 1];

                    if (pathUp > pathLeft)
                    {
                        solutions[row, col] = pathUp;
                    }
                    else
                    {
                        solutions[row, col] = pathLeft;
                    }
                }
            }
        }

        private static void InitializeMatrix(int rowsCount, int colsCount)
        {
            matrix = new int[rowsCount, colsCount];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentLine = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentLine[col];
                }
            }
        }
    }
}
