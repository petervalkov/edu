namespace _01._Fibonacci
{
    using System;

    public class Program
    {
        private static long[] memo;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            memo = new long[n + 1];

            Console.WriteLine(Fibonacci(n));
        }

        private static long Fibonacci(int n)
        {
            if (memo[n] != 0)
            {
                return memo[n];
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
