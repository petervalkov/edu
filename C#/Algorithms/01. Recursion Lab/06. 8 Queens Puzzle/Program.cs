namespace _06._8_Queens_Puzzle
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            Board board = new Board();

            board.Initialize();
            board.PlaceQueen();
        }

        public class Board
        {
            private const int SIZE = 8;

            private readonly int[][] field;
            private readonly HashSet<int> attackedCols;
            private readonly HashSet<int> attackedFirsDiagonal;
            private readonly HashSet<int> attackedSecondDiagonal;

            public Board()
            {
                this.field = new int[SIZE][];
                this.attackedCols = new HashSet<int>();
                this.attackedFirsDiagonal = new HashSet<int>();
                this.attackedSecondDiagonal = new HashSet<int>();
            }

            public void Initialize()
            {
                for (int i = 0; i < SIZE; i++)
                {
                    this.field[i] = new int[SIZE];
                }
            }

            public void PlaceQueen(int row = 0)
            {
                if (row == SIZE)
                {
                    Print();
                }
                else
                {
                    for (int col = 0; col < SIZE; col++)
                    {
                        if (PositionAvailable(row, col))
                        {
                            MarkAttackedPositions(row, col);
                            PlaceQueen(row + 1);
                            UnmarkAttackedPositions(row, col);
                        }
                    }
                }
            }

            private bool PositionAvailable(int row, int col)
            {
                if (this.attackedCols.Contains(col) || this.attackedFirsDiagonal.Contains(row + col) || this.attackedSecondDiagonal.Contains(row - col))
                {
                    return false;
                }

                return true;
            }

            private void MarkAttackedPositions(int row, int col)
            {
                this.attackedCols.Add(col);
                this.attackedFirsDiagonal.Add(row + col);
                this.attackedSecondDiagonal.Add(row - col);
                this.field[row][col] = 1;
            }

            private void UnmarkAttackedPositions(int row, int col)
            {
                this.attackedCols.Remove(col);
                this.attackedFirsDiagonal.Remove(row + col);
                this.attackedSecondDiagonal.Remove(row - col);
                this.field[row][col] = 0;
            }

            private void Print()
            {
                for (int row = 0; row < SIZE; row++)
                {
                    Console.WriteLine(string.Join(" ", this.field[row].Select(x => x == 1 ? "*" : "-")));
                }

                Console.WriteLine();
            }
        }
    }
}
