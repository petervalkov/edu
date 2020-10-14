namespace _09._SumUnlimitedCoins
{
    using System;
    using System.Linq;

    public class Program
    {
        static int[] coins;

        public static void Main(string[] args)
        {
            coins = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int coinsCount = coins.Length;
            int sum = int.Parse(Console.ReadLine());

            Console.WriteLine(ChangeCount(coinsCount, sum));
        }

        private static int ChangeCount(int coinsCount, int sum)
        {
            if (sum == 0)
            {
                return 1;
            }

            if (coinsCount <= 0 && sum >= 1 || sum < 0)
            {
                return 0;
            }

            return ChangeCount(coinsCount - 1, sum) + ChangeCount(coinsCount, sum - coins[coinsCount - 1]);
        }
    }
}
