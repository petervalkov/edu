namespace _01._Recursive_Array_Sum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int index = 0;
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(CalculateSum(input, index));
        }

        private static int CalculateSum(int[] input, int index)
        {
            if (index == input.Length - 1)
            {
                return input[index];
            }

            return input[index] + CalculateSum(input, index + 1);
        }
    }
}
