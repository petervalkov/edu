namespace _05._Combinations_without_Repetition
{
    using System;
    using System.Linq;

    public class Program
    {
        static int[] numbers;
        static int[] vector;

        public static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());
            numbers = Enumerable.Range(1, numbersCount).ToArray();

            int vectorLength = int.Parse(Console.ReadLine());
            vector = new int[vectorLength];

            GenerateCombinations(0, 0, vector, numbers);
        }

        private static void GenerateCombinations(int index, int border, int[] vector, int[] numbers)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = border; i < numbers.Length; i++)
                {
                    vector[index] = numbers[i];
                    GenerateCombinations(index + 1, i + 1, vector, numbers);
                }
            }
        }
    }
}
