namespace _05._Knapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static int[,] bestPrice;
        static bool[,] included;
        static List<Item> items;

        public static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            items = new List<Item>();
            ReadItems();

            bestPrice = new int[items.Count + 1, capacity + 1];
            included = new bool[items.Count + 1, capacity + 1];
            Solve(capacity);

            int currentCapacity = capacity;
            List<Item> output = new List<Item>();

            for (int i = items.Count - 1; i >= 0; i--)
            {
                if (included[i + 1, currentCapacity])
                {
                    output.Add(items[i]);
                    currentCapacity -= items[i].Weight;
                }
            }

            output.Reverse();

            Console.WriteLine($"Total Weight: {output.Sum(i => i.Weight)}");
            Console.WriteLine($"Total Value: {bestPrice[bestPrice.GetLength(0) - 1, bestPrice.GetLength(1) - 1]}");
            Console.WriteLine(string.Join("\n", output.Select(i => i.Name)));
        }

        private static void Solve(int capacity)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Item item = items[i];

                for (int j = 0; j <= capacity; j++)
                {
                    if (item.Weight > j)
                    {
                        continue;
                    }

                    int valueIfExcluded = bestPrice[i, j];
                    int valueIfIncluded = item.Value + bestPrice[i, j - item.Weight];

                    if (valueIfIncluded > valueIfExcluded)
                    {
                        bestPrice[i + 1, j] = valueIfIncluded;
                        included[i + 1, j] = true;
                    }
                    else
                    {
                        bestPrice[i + 1, j] = valueIfExcluded;
                    }
                }
            }
        }

        private static void ReadItems()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] itemDetails = input.Split();

                string name = itemDetails[0];
                int weigth = int.Parse(itemDetails[1]);
                int value = int.Parse(itemDetails[2]);

                items.Add(new Item { Name = name, Weight = weigth, Value = value });
            }

            items = items.OrderBy(i => i.Name).ToList();
        }
    }
}
