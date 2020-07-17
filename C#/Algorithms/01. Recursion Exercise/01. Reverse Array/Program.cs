namespace _01._Reverse_Array
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            ReverseElements(arr, 0, arr.Length - 1);
        }

        private static void ReverseElements(int[] arr, int lowerIndex, int upperIndex)
        {
            if (lowerIndex >= upperIndex)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            int temp = arr[lowerIndex];
            arr[lowerIndex] = arr[upperIndex];
            arr[upperIndex] = temp;

            ReverseElements(arr, lowerIndex + 1, upperIndex - 1);
        }
    }
}
