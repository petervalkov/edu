namespace _01._Fractional_Knapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        static void Main(string[] args)
        {
            double freeCapacity = int.Parse(Console.ReadLine().Split()[1]);
            int itemsCount = int.Parse(Console.ReadLine().Split()[1]);

            List<Item> items = new List<Item>();

            for (int i = 0; i < itemsCount; i++)
            {
                string[] itemInput = Console.ReadLine()
                    .Split();

                double itemPrice = int.Parse(itemInput[0]);
                double itemWeight = int.Parse(itemInput[2]);

                items.Add(new Item() { Price = itemPrice, Weight = itemWeight });
            }

            double totalPrice = 0;
            StringBuilder output = new StringBuilder();
            Queue<Item> orderedItems = new Queue<Item>(items.OrderByDescending(x => x.Price / x.Weight));

            while (orderedItems.Count > 0)
            {
                Item currentItem = orderedItems.Dequeue();

                if (currentItem.Weight >= freeCapacity)
                {
                    double percentage = freeCapacity / currentItem.Weight;
                    totalPrice += currentItem.Price * percentage;
                    output.AppendLine($"Take {percentage * 100:F2}% of item with price {currentItem.Price:F2} and weight {currentItem.Weight:F2}");
                    break;
                }
                else
                {
                    totalPrice += currentItem.Price;
                    freeCapacity -= currentItem.Weight;
                    output.AppendLine($"Take 100% of item with price {currentItem.Price:F2} and weight {currentItem.Weight:F2}");
                }
            }

            output.AppendLine($"Total price: {totalPrice:F2}");
            Console.WriteLine(output.ToString().TrimEnd());
        }
    }
}
