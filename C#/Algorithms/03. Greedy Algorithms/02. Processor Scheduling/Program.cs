namespace _02._Processor_Scheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine().Split()[1]);
            List<Task> tasks = new List<Task>();

            for (int i = 1; i <= count; i++)
            {
                int[] input = Console.ReadLine().Split('-').Select(x => int.Parse(x.Trim())).ToArray();
                tasks.Add(new Task() { Index = i, Value = input[0], Deadline = input[1] });
            }

            int deadlineMax = tasks.Max(t => t.Deadline);
            bool[] used = new bool[deadlineMax];
            List<Task> output = new List<Task>();

            foreach (var task in tasks.OrderByDescending(t => t.Value).ThenBy(t => t.Deadline))
            {
                for (var i = task.Deadline - 1; i >= 0; i--)
                {
                    if (used[i])
                    {
                        continue;
                    }

                    used[i] = true;
                    output.Add(task);
                    break;
                }
            }

            output = output.OrderBy(t => t.Deadline).ThenByDescending(t => t.Value).ToList();
            Console.WriteLine($"Optimal schedule: {string.Join(" -> ", output.Select(t => t.Index))}");
            Console.WriteLine($"Total value: {output.Sum(t => t.Value)}");
        }
    }
}
