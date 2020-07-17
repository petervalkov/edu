namespace _05._Words
{
    using System;

    public class Program
    {
        private static int count;

        public static void Main()
        {
            var arr = Console.ReadLine().ToCharArray();
            Array.Sort(arr);
            PermuteRep(arr, 0, arr.Length - 1);
            Console.WriteLine(count);
        }

        private static bool ConsecutiveLetter(char[] word)
        {
            for (int i = 0; i < word.Length - 1; i++)
            {
                if (word[i].Equals(word[i + 1]))
                {
                    return true;
                }
            }

            return false;
        }

        private static void PermuteRep(char[] arr, int start, int end)
        {
            if (!ConsecutiveLetter(arr))
            {
                count++;
            }

            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermuteRep(arr, left + 1, end);
                    }
                }

                var firstElement = arr[left];
                for (int i = left; i <= end - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }

                arr[end] = firstElement;
            }
        }

        private static void Swap(ref char first, ref char second)
        {
            char oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
