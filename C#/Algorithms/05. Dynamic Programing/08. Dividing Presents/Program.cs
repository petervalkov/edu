namespace _08._Dividing_Presents
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int[] presents = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int totalSum = presents.Sum();
            int[] solution = new int[totalSum + 1];

            for (int i = 1; i < solution.Length; i++)
            {
                solution[i] = -1;
            }

            for (int i = 0; i < presents.Length; i++)
            {
                for (int j = solution.Length - presents[i]; j >= 0; j--)
                {
                    if (solution[j] != -1 && solution[j + presents[i]] == -1)
                    {
                        solution[j + presents[i]] = i;
                    }
                }
            }

            int alanSum = 0;
            List<int> output = new List<int>();

            for (int i = (solution.Length - 1) / 2; i >= 0; i--)
            {
                if (solution[i] != -1)
                {
                    alanSum = i;
                    while (i > 0)
                    {
                        output.Add(presents[solution[i]]);
                        i -= presents[solution[i]];
                    }

                    break;
                }
            }

            int bobSum = totalSum - alanSum;
            int difference = bobSum - alanSum;

            Console.WriteLine("Difference: " + difference);
            Console.WriteLine("Alan:" + alanSum + " Bob:" + bobSum);
            Console.WriteLine("Alan takes: " + string.Join(" ", output));
            Console.WriteLine("Bob takes the rest.");
        }
    }
}
