namespace _05._Generating_Combinations
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int vectorLength = int.Parse(Console.ReadLine());

            int[] vector = new int[vectorLength];

            GenerateCombination(0, 0, vector, elements);
        }

        private static void GenerateCombination(int index, int border, int[] vector, int[] elements)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = border; i < elements.Length; i++)
                {
                    vector[index] = elements[i];
                    GenerateCombination(index + 1, i + 1, vector, elements);
                }
            }
        }
    }
}
