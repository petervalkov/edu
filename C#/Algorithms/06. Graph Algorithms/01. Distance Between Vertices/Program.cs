namespace _01._Distance_Between_Vertices
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        static Dictionary<int, List<int>> graph;
        static int[] distances;

        public static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            int pairsCount = int.Parse(Console.ReadLine());

            InitializeGraph(nodesCount);

            for (int i = 0; i < pairsCount; i++)
            {
                string[] pairDetails = Console.ReadLine().Split('-');
                int startNode = int.Parse(pairDetails[0]);
                int endNode = int.Parse(pairDetails[1]);

                Console.WriteLine($"{{{startNode}, {endNode}}} -> {FindShortestPath(startNode, endNode)}");
            }
        }

        private static int FindShortestPath(int startNode, int endNode)
        {
            distances = Enumerable.Repeat(-1, graph.Max(n => n.Key) + 1).ToArray();
            distances[startNode] = 0;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                int currentNode = queue.Dequeue();

                foreach (var neighbour in graph[currentNode])
                {
                    if (distances[neighbour] == -1)
                    {
                        distances[neighbour] = distances[currentNode] + 1;

                        if (neighbour == endNode)
                        {
                            return distances[endNode];
                        }

                        queue.Enqueue(neighbour);
                    }
                }
            }

            return distances[endNode];
        }

        private static void InitializeGraph(int nodesCount)
        {
            graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < nodesCount; i++)
            {
                string[] nodeDetails = Console.ReadLine().Split(':');
                int nodeId = int.Parse(nodeDetails[0]);
                graph[nodeId] = new List<int>();

                if (nodeDetails[1].Count() > 0)
                {
                    graph[nodeId] = nodeDetails[1].Split().Select(int.Parse).ToList();
                }
            }
        }
    }
}
