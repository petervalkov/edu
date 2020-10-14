namespace _04._Rod_Cutting
{
    using System;
    using System.Linq;

    public class Program
    {
        static int[] bestPrice;
        static int[] bestCombo;
        static int[] prices;

        public static void Main(string[] args)
        {
            prices = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int ropeLength = int.Parse(Console.ReadLine());

            bestPrice = new int[prices.Length];
            bestCombo = new int[prices.Length];

            Console.WriteLine(CalculateBestPrice(ropeLength));
            PrintBestCombo(ropeLength);
        }

        private static void PrintBestCombo(int ropeLength)
        {
            while (ropeLength - bestCombo[ropeLength] != 0)
            {
                Console.Write(bestCombo[ropeLength] + " ");
                ropeLength -= bestCombo[ropeLength];
            }

            Console.WriteLine(bestCombo[ropeLength]);
        }

        private static int CalculateBestPrice(int ropeLength)
        {
            if (bestPrice[ropeLength] > 0)
            {
                return bestPrice[ropeLength];
            }

            if (ropeLength == 0)
            {
                return 0;
            }

            int currentBestPrice = bestPrice[ropeLength];

            for (int i = 1; i <= ropeLength; i++)
            {
                currentBestPrice = Math.Max(currentBestPrice, prices[i] + CalculateBestPrice(ropeLength - i));

                if (currentBestPrice > bestPrice[ropeLength])
                {
                    bestPrice[ropeLength] = currentBestPrice;
                    bestCombo[ropeLength] = i;
                }
            }

            return bestPrice[ropeLength];
        }
    }
}
