namespace _04._VariationsNoRep
{
    using System;
    using System.Linq;

    public class Program
    {
        static char[] input;
        static bool[] used;
        static char[] output;

        public static void Main(string[] args)
        {
            input = Console.ReadLine()
                .Split()
                .Select(char.Parse)
                .ToArray();

            int outputCount = int.Parse(Console.ReadLine());

            used = new bool[input.Length];
            output = new char[outputCount];

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
                    if (!used[i])
                    {
                        output[index] = input[i];
                        used[i] = true;
                        Solve(index + 1);
                        used[i] = false;
                    }
                }
            }
        }
    }
}
