namespace _06._Merge_Sort
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

            MergeSort(arr, 0, arr.Length - 1);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void MergeSort(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int middle = (start + end) / 2;

            MergeSort(arr, start, middle);
            MergeSort(arr, middle + 1, end);
            Merge(arr, start, middle, end);
        }

        private static void Merge(int[] arr, int start, int middle, int end)
        {
            if (middle < 0 || middle + 1 >= arr.Length || arr[middle] <= arr[middle + 1])
            {
                return;
            }

            int[] temp = new int[arr.Length];

            int leftIndex = start;
            int rightIndex = middle + 1;

            for (int i = start; i <= end; i++)
            {
                temp[i] = arr[i];
            }

            for (int i = start; i <= end; i++)
            {
                if (leftIndex > middle)
                {
                    arr[i] = temp[rightIndex++];
                }
                else if (rightIndex > end)
                {
                    arr[i] = temp[leftIndex++];
                }
                else if (temp[leftIndex] < temp[rightIndex])
                {
                    arr[i] = temp[leftIndex++];
                }
                else
                {
                    arr[i] = temp[rightIndex++];
                }
            }
        }
    }
}
