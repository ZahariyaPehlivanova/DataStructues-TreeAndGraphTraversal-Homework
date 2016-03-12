namespace _02.RoundDance
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static int longestRoundDance;
        private static IDictionary<int, IList<int>> nodes =
            new Dictionary<int, IList<int>>();
        private static int leader;

        static void Main()
        {
            int friendships = int.Parse(Console.ReadLine());
            leader = int.Parse(Console.ReadLine());

            for (int i = 0; i < friendships; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                int node = int.Parse(input[0]);
                int neighbour = int.Parse(input[1]);

                AddNode(node, neighbour);
                AddNode(neighbour, node);
            }

            FindLongestRoundDance(leader, leader);

            Console.WriteLine(longestRoundDance);
        }

        private static void FindLongestRoundDance(int node, int prevNode, int count = 0)
        {
            count++;

            foreach (var neighbour in nodes[node])
            {
                if (neighbour == prevNode)
                {
                    continue;
                }

                FindLongestRoundDance(neighbour, node, count);
            }

            if (count > longestRoundDance)
            {
                longestRoundDance = count;
            }
        }

        private static void AddNode(int node, int neighbour)
        {
            if (!nodes.ContainsKey(node))
            {
                nodes.Add(node, new List<int>());
            }

            nodes[node].Add(neighbour);
        }
    }
}
