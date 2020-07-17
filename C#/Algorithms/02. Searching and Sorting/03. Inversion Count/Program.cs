namespace _03._Inversion_Count
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

            int inversionCount = MergeSort(arr, 0, arr.Length - 1);

            Console.WriteLine(inversionCount);
        }

        public static int MergeSort(int[] arr, int start, int end)
        {
            int inversionCount = 0;

            if (start < end)
            {
                int mid = (start + end) / 2;

                inversionCount = MergeSort(arr, start, mid);
                inversionCount += MergeSort(arr, mid + 1, end);
                inversionCount += Merge(arr, start, mid, end);
            }

            return inversionCount;
        }

        public static int Merge(int[] arr, int start, int mid, int end)
        {
            int inversionCount = 0;

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
                    inversionCount += firstSize - firstArrIndex;
                }
            }

            return inversionCount;
        }
    }
}
