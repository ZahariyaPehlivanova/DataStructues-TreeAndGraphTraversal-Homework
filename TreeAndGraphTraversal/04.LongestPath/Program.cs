namespace _04.LongestPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static IDictionary<int, IList<int>> childNodes;
        private static IDictionary<int, int?> parents;
        private static IDictionary<int, int> nodeToRootSum;

        static void Main()
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());
            
            childNodes = new Dictionary<int, IList<int>>(nodes);
            parents = new Dictionary<int, int?>(nodes);
            nodeToRootSum = new Dictionary<int, int>(nodes);

            for (int i = 0; i < edges; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                int parent = int.Parse(input[0]);
                int child = int.Parse(input[1]);

                AddPair(parent, child);
            }

            foreach (var node in childNodes.Keys)
            {
                nodeToRootSum[node] = 0;
            }

            var root = FindRoot();
            DepthFirstSearch(root, 0);

            var longestPath = 0;
            longestPath = FindLongestPath(longestPath);

            Console.WriteLine(longestPath);
        }

        private static void AddPair(int parent, int child)
        {
            if (!childNodes.ContainsKey(parent))
            {
                childNodes[parent] = new List<int>();
            }

            childNodes[parent].Add(child);

            if (!childNodes.ContainsKey(child))
            {
                childNodes[child] = new List<int>();
            }

            if (!parents.ContainsKey(parent))
            {
                parents[parent] = null;
            }

            parents[child] = parent;
        }
        
        private static int FindLongestPath(int longestPath)
        {
            foreach (var nodeA in nodeToRootSum)
            {
                foreach (var nodeB in nodeToRootSum)
                {
                    if (nodeA.Key != nodeB.Key)
                    {
                        var currentPath = nodeA.Value - nodeB.Value + nodeB.Key;
                        if (currentPath > longestPath)
                        {
                            longestPath = currentPath;
                        }
                    }
                }
            }

            return longestPath;
        }

        private static int FindRoot()
        {
            var root = parents.FirstOrDefault(node => node.Value == null).Key;

            return root;
        }

        private static void DepthFirstSearch(int node, int totalSum)
        {
            totalSum += node;
            nodeToRootSum[node] = totalSum;

            foreach (var child in childNodes[node])
            {
                DepthFirstSearch(child, totalSum);
            }
        }
    }
}
