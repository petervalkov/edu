namespace _02._PermutationsNoRep
{
    using System;
    using System.Linq;

    public class Program
    {
        static char[] input;

        public static void Main(string[] args)
        {
            input = Console.ReadLine()
                .Split()
                .Select(char.Parse)
                .ToArray();

            Solve(0);
        }

        private static void Solve(int index)
        {
            if (index >= input.Length)
            {
                Console.WriteLine(string.Join(" ", input));
            }
            else
            {
                Solve(index + 1);

                for (int i = index + 1; i < input.Length; i++)
                {
                    Swap(index, i);
                    Solve(index + 1);
                    Swap(index, i);
                }
            }
        }

        private static void Swap(int first, int second)
        {
            char temp = input[first];
            input[first] = input[second];
            input[second] = temp;
        }
    }
}
