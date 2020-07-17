namespace _06._Connected_Areas_in_Matrix
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        private static char[,] field;
        private static int currentArea = 0;
        private static readonly Dictionary<int[], int> areas = new Dictionary<int[], int>();

        public static void Main(string[] args)
        {
            InitializeField();

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    GetArea(row, col);

                    if (currentArea > 0)
                    {
                        int[] coordinates = new int[] { row, col };
                        areas.Add(coordinates, currentArea);
                        currentArea = 0;
                    }
                }
            }

            Console.WriteLine($"Total areas found: {areas.Count}");

            int counter = 0;
            foreach (var area in areas.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"Area #{++counter} at ({area.Key[0]}, {area.Key[1]}), size: {area.Value}");
            }
        }

        private static void InitializeField()
        {
            int fieldRows = int.Parse(Console.ReadLine());
            int fieldCols = int.Parse(Console.ReadLine());
            field = new char[fieldRows, fieldCols];

            for (int row = 0; row < field.GetLength(0); row++)
            {
                string currentrow = Console.ReadLine();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = currentrow[col];
                }
            }
        }

        private static void GetArea(int row, int col)
        {
            if (IsInRange(row, col))
            {
                field[row, col] = '*';
                currentArea++;

                GetArea(row + 1, col);
                GetArea(row - 1, col);
                GetArea(row, col + 1);
                GetArea(row, col - 1);
            }
        }

        private static bool IsInRange(int row, int col)
        {
            if (row < 0 || col < 0 || row >= field.GetLength(0) || col >= field.GetLength(1))
            {
                return false;
            }

            return field[row, col] != '*';
        }
    }
}
