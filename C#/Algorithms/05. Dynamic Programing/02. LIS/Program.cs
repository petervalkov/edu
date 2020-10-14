namespace _02._LIS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static int[] elements;
        static int[] length;
        static int[] parent;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            parent = Enumerable.Repeat(-1, elements.Length).ToArray();
            length = Enumerable.Repeat(1, elements.Length).ToArray();

            length[0] = 1;
            int maxLen = 0;
            int index = -1;

            for (int i = 0; i < elements.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (elements[i] > elements[j] && length[j] + 1 > length[i])
                    {
                        length[i] = length[j] + 1;
                        parent[i] = j;
                    }
                }

                if (length[i] > maxLen)
                {
                    maxLen = length[i];
                    index = i;
                }
            }

            List<int> result = new List<int>();
            while (index != -1)
            {
                result.Add(elements[index]);
                index = parent[index];
            }

            result.Reverse();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
