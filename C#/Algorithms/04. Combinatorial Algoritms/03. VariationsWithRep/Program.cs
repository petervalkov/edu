namespace _03._VariationsWithRep
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

            int outputLength = int.Parse(Console.ReadLine());
            output = new char[outputLength];

            Solve(0);
        }

        private static void Solve(int index)
        {
            if (index >= output.Length)
            {
                Console.WriteLine(string.Join(" ", output));
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    output[index] = input[i];
                    Solve(index + 1);
                }
            }
        }
    }
}
