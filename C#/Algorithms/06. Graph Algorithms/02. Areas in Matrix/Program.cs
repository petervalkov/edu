namespace _02._Areas_in_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static char[][] matrix;
        static bool[,] visited;
        static Dictionary<char, int> result;

        public static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());
            matrix = new char[rowsCount][];

            for (int i = 0; i < rowsCount; i++)
            {
                matrix[i] = Console.ReadLine().Trim().ToCharArray();
            }

            visited = new bool[rowsCount, matrix[0].Length];
            result = new Dictionary<char, int>();

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (!visited[row, col])
                    {
                        if (!result.ContainsKey(matrix[row][col]))
                        {
                            result[matrix[row][col]] = 1;
                        }
                        else
                        {
                            result[matrix[row][col]]++;
                        }

                        TraverseNeighbours(row, col, matrix[row][col]);
                    }
                }
            }

            Console.WriteLine($"Areas: {result.Values.Sum()}");
            foreach (var item in result.OrderBy(r => r.Key))
            {
                Console.WriteLine($"Letter '{item.Key}' -> {item.Value}");
            }
        }

        private static void TraverseNeighbours(int row, int col, char value)
        {
            if (IsInRange(row, col) && !visited[row, col] && matrix[row][col] == value)
            {
                visited[row, col] = true;

                TraverseNeighbours(row + 1, col, matrix[row][col]);
                TraverseNeighbours(row - 1, col, matrix[row][col]);
                TraverseNeighbours(row, col + 1, matrix[row][col]);
                TraverseNeighbours(row, col - 1, matrix[row][col]);
            }
        }

        private static bool IsInRange(int row, int col)
        {
            return row >= 0
                && row < visited.GetLength(0)
                && col >= 0
                && col < visited.GetLength(1);
        }
    }
}
