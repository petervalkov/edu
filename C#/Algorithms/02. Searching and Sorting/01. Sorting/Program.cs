namespace _01._Sorting
{
    using System;
    using System.Linq;
 
    public class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

            MergeSort(arr, 0, arr.Length - 1);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void MergeSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;
                MergeSort(arr, start, mid);
                MergeSort(arr, mid + 1, end);
                Merge(arr, start, mid, end);
            }
        }

        private static void Merge(int[] arr, int start, int mid, int end)
        {
            int firstSize = mid - start + 1;
            int secondSize = end - mid;
            int[] firstArr = new int[firstSize + 1];
            int[] secondArr = new int[secondSize + 1];

            for (int i = 0; i < firstSize; i++)
            {
                firstArr[i] = arr[start + i];
            }

            for (int i = 0; i < secondSize; i++)
            {
                secondArr[i] = arr[mid + 1 + i];
            }

            firstArr[firstSize] = Int32.MaxValue;
            secondArr[secondSize] = Int32.MaxValue;
            int firstArrIndex = 0;
            int secondArrIndex = 0;

            for (int i = start; i <= end; i++)
            {
                if (firstArr[firstArrIndex] <= secondArr[secondArrIndex])
                {
                    arr[i] = firstArr[firstArrIndex];
                    firstArrIndex++;
                }
                else
                {
                    arr[i] = secondArr[secondArrIndex];
                    secondArrIndex++;
                }
            }
        }
    }
}
