namespace _07._N_Choose_K
{
    using System;
    using System.Numerics;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            BigInteger output = GetFactorial(n) / (GetFactorial(n - k) * GetFactorial(k));

            Console.WriteLine(output);
        }

        private static BigInteger GetFactorial(int number)
        {
            BigInteger result = 1;

            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
