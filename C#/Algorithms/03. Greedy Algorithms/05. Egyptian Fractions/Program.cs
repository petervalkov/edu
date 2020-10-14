namespace _05._Egyptian_Fractions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] fraction = input.Split('/')
                .Select(int.Parse)
                .ToArray();

            int numerator = fraction[0];
            int denominator = fraction[1];

            if (numerator >= denominator)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
                return;
            }

            Console.Write($"{input} = ");

            List<int> output = new List<int>();
            int index = 2;

            while (numerator > 0)
            {
                int newNumerator = (numerator * index) - denominator;

                if (newNumerator < 0)
                {
                    index++;
                    continue;
                }

                output.Add(index);
                numerator = newNumerator;
                denominator *= index++;
            }

            Console.WriteLine(string.Join(" + ", output.Select(x => $"1/{x}")));
        }
    }
}
