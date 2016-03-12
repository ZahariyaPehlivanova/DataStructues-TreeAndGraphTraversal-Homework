namespace _01.FindTheRoot
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            bool[] hasRoot = new bool[n];
            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                int parentNode = int.Parse(input[0]);
                int childNode = int.Parse(input[1]);

                hasRoot[childNode] = true;
            }

            var nodesWithoutRoot = new List<int>();

            for (int node = 0; node < n; node++)
            {
                if (!hasRoot[node])
                {
                    nodesWithoutRoot.Add(node);
                }
            }

            switch (nodesWithoutRoot.Count)
            {
                case 0:
                    Console.WriteLine("No root!");
                    break;
                case 1:
                    Console.WriteLine(nodesWithoutRoot[0]);
                    break;
                default:
                    Console.WriteLine("Multiple root nodes! [{0}]", string.Join(", ", nodesWithoutRoot));
                    break;
            }
        }
    }
}
