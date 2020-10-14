namespace _06._Binomial_Coefficient
{
    using System;

    public class Program
    {
        static long[][] pascalTriangle;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            pascalTriangle = new long[n + 1][];
            pascalTriangle[0] = new long[] { 1 };

            Console.WriteLine(BinomalCoefficient(n, k));
        }

        public static long BinomalCoefficient(int n, int k)
        {
            if (pascalTriangle[n] == null)
            {
                pascalTriangle[n] = new long[n + 1];
            }

            if (k < 0 || k >= pascalTriangle[n].Length)
            {
                return 0;
            }

            if (pascalTriangle[n][k] != 0)
            {
                return pascalTriangle[n][k];
            }

            pascalTriangle[n][k] = BinomalCoefficient(n - 1, k - 1) + BinomalCoefficient(n - 1, k);
            return pascalTriangle[n][k];
        }
    }
}
