namespace _02._Nested_Loops
{
    using System;

    public class Program
    {
        static int[] arr;

        public static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            arr = new int[count];

            GenerateCombinations(0);
        }

        private static void GenerateCombinations(int index)
        {
            if (arr.Length == index)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 1; i <= arr.Length; i++)
            {
                arr[index] = i;
                GenerateCombinations(index + 1);
            }
        }
    }
}
