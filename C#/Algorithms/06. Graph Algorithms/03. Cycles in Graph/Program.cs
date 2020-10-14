namespace _03._Cycles_in_Graph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static Dictionary<char, List<char>> graph;
        static HashSet<char> visited;
        static bool result;

        public static void Main(string[] args)
        {
            graph = new Dictionary<char, List<char>>();
            visited = new HashSet<char>();

            string input = string.Empty;

            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                char[] edge = input
                    .Trim()
                    .Split('-') // Change to "–" for judge
                    .Select(char.Parse)
                    .ToArray();

                AddNodeToGraph(edge[0], edge[1]);
                AddNodeToGraph(edge[1], edge[0]);
            }

            foreach (var node in graph)
            {
                CheckIfAcyclic(node.Key, ' ');
            }

            Console.WriteLine($"Acyclic: {(result ? "No" : "Yes")}");
        }

        private static void CheckIfAcyclic(char node, char parent)
        {
            if (visited.Contains(node))
            {
                result = true;
                return;
            }

            visited.Add(node);

            foreach (char child in graph[node])
            {
                if (child != parent)
                {
                    CheckIfAcyclic(child, node);
                }
            }

            visited.Remove(node);
        }

        private static void AddNodeToGraph(char parent, char child)
        {
            if (!graph.ContainsKey(parent))
            {
                graph[parent] = new List<char>();
            }

            graph[parent].Add(child);
        }
    }
}
