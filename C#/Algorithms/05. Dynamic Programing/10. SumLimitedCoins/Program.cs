namespace _10._SumLimitedCoins
{
    using System;
    using System.Linq;

    public class Program
    {
        static int[] coins;
        static int sum;

        public static void Main()
        {
            coins = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

            sum = int.Parse(Console.ReadLine());

            Console.WriteLine(ChangeCount());
        }

        private static int ChangeCount()
        {
            int[,] solution = new int[coins.Length + 1, sum + 1];

            for (int i = 0; i <= coins.Length; i++)
            {
                solution[i, 0] = 1;
            }

            for (int i = 1; i <= coins.Length; i++)
            {
                for (int j = sum; j >= 0; j--)
                {
                    if (coins[i - 1] <= j && solution[i - 1, j - coins[i - 1]] != 0)
                    {
                        solution[i, j]++;
                    }
                    else
                    {
                        solution[i, j] = solution[i - 1, j];
                    }
                }
            }

            int count = 0;

            for (int i = 0; i < coins.Length + 1; i++)
            {
                if (solution[i, sum] != 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
