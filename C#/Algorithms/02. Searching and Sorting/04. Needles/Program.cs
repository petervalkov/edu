namespace _04._Needles
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        static readonly List<int> result = new List<int>();

        public static void Main()
        {
            string input = Console.ReadLine();
            List<int> hayStack = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> needles = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            foreach (var needle in needles)
            {
                bool match = false;

                for (int i = 0; i < hayStack.Count; i++)
                {
                    if (hayStack[i] >= needle)
                    {
                        match = true;
                        ReturnIndex(hayStack, i - 1);
                        break;
                    }
                }

                if (!match)
                {
                    ReturnIndex(hayStack, hayStack.Count - 1);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }

        private static void ReturnIndex(List<int> nums, int i)
        {
            while (i >= 0)
            {
                if (nums[i] != 0)
                {
                    result.Add(i + 1);
                    return;
                }

                i--;
            }

            result.Add(0);
        }
    }
}
