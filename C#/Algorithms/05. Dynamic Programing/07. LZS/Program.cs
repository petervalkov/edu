namespace _07._LZS
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] solution = new int[numbers.Length, 2];
            int[,] prevIndex = new int[numbers.Length, 2];

            solution[0, 0] = 1;
            solution[0, 1] = 1;

            prevIndex[0, 0] = -1;
            prevIndex[0, 1] = -1;

            int longestSubSCount = 0;
            int lastIndexRow = -1;
            int lastIndexCol = -1;

            for (int i = 1; i < numbers.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (numbers[i] > numbers[j] && solution[j, 1] + 1 > solution[i, 0])
                    {
                        solution[i, 0] = solution[j, 1] + 1;
                        prevIndex[i, 0] = j;
                    }

                    if (numbers[i] < numbers[j] && solution[j, 0] + 1 > solution[i, 1])
                    {
                        solution[i, 1] = solution[j, 0] + 1;
                        prevIndex[i, 1] = j;
                    }
                }

                if (solution[i, 0] > longestSubSCount)
                {
                    longestSubSCount = solution[i, 0];
                    lastIndexRow = i;
                    lastIndexCol = 0;
                }

                if (solution[i, 1] > longestSubSCount)
                {
                    longestSubSCount = solution[i, 1];
                    lastIndexRow = i;
                    lastIndexCol = 1;
                }
            }

            var result = new List<int>();

            while (lastIndexRow >= 0)
            {
                result.Add(numbers[lastIndexRow]);
                lastIndexRow = prevIndex[lastIndexRow, lastIndexCol];

                if (lastIndexCol == 1)
                {
                    lastIndexCol = 0;
                }
                else
                {
                    lastIndexCol = 1;
                }
            }

            result.Reverse();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
