namespace _05._Break_Cycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static SortedDictionary<char, List<char>> graph;
        static HashSet<char> visited;

        public static void Main(string[] args)
        {
            graph = new SortedDictionary<char, List<char>>();
            string input = string.Empty;

            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                char[] nodeArgs = input
                    .Split(new[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                graph[nodeArgs[0]] = nodeArgs.Skip(1).ToList();
            }

            List<string> result = new List<string>();

            foreach (var node in graph)
            {
                char start = node.Key;

                foreach (var child in graph[start].OrderBy(e => e))
                {
                    graph[start].Remove(child);
                    graph[child].Remove(start);

                    if (HasCycle(start, child))
                    {
                        result.Add($"{start} - {child}");
                    }
                    else
                    {
                        graph[start].Add(child);
                        graph[child].Add(start);
                    }
                }
            }

            Console.WriteLine($"Edges to remove: {result.Count}");

            foreach (var edge in result)
            {
                Console.WriteLine(edge);
            }
        }

        private static bool HasCycle(char startNode, char endNode)
        {
            visited = new HashSet<char>();
            Queue<char> queue = new Queue<char>();

            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                char currentNode = queue.Dequeue();

                if (!visited.Contains(currentNode))
                {
                    visited.Add(currentNode);

                    foreach (var child in graph[currentNode])
                    {
                        if (child == endNode)
                        {
                            return true;
                        }

                        queue.Enqueue(child);
                    }
                }
            }

            return false;
        }
    }
}
