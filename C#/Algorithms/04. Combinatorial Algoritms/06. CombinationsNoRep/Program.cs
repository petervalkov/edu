namespace _06._CombinationsNoRep
{
    using System;
    using System.Linq;

    public class Program
    {
        static char[] input;
        static char[] output;

        public static void Main(string[] args)
        {
            input = Console.ReadLine()
                .Split()
                .Select(Char.Parse)
                .ToArray();

            int k = int.Parse(Console.ReadLine());
            output = new char[k];

            Solve(0, 0);
        }

        private static void Solve(int index, int start)
        {
            if (index >= output.Length)
            {
                Console.WriteLine(String.Join(" ", output));
            }
            else
            {
                for (int i = start; i < input.Length; i++)
                {
                    output[index] = input[i];
                    Solve(index + 1, i + 1);
                }
            }
        }
    }
}
