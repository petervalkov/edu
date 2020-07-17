namespace _04._Tower_Of_Hanoi
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        private static int steps = 0;
        private static Stack<int> source;
        private static readonly Stack<int> destination = new Stack<int>();
        private static readonly Stack<int> spare = new Stack<int>();

        public static void Main(string[] args)
        {
            int discsCount = int.Parse(Console.ReadLine());
            source = new Stack<int>(Enumerable.Range(1, discsCount).Reverse());

            Print();
            Solve(discsCount, source, destination, spare);
        }

        private static void Solve(int bottom, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottom == 1)
            {
                destination.Push(source.Pop());

                Console.WriteLine($"Step #{++steps}: Moved disk");
                Print();
            }
            else
            {
                Solve(bottom - 1, source, spare, destination);

                destination.Push(source.Pop());

                Console.WriteLine($"Step #{++steps}: Moved disk");
                Print();

                Solve(bottom - 1, spare, destination, source);
            }
        }

        private static void Print()
        {
            Console.WriteLine($"Source: {string.Join(", ", source.Reverse())}");
            Console.WriteLine($"Destination: {string.Join(", ", destination.Reverse())}");
            Console.WriteLine($"Spare: {string.Join(", ", spare.Reverse())}\n");
        }
    }
}
