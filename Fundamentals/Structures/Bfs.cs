using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    internal class Bfs
    {
        public static IList<IntNode> FindNode(int value, IntNode root)
        {
            var visitedNodes = new HashSet<IntNode>();
            var queue = new Queue<IntNode>();
            var parents = new Dictionary<IntNode, IntNode>();

            visitedNodes.Add(root);
            queue.Enqueue(root);

            while (queue.Any())
            {
                var node = queue.Dequeue();
                Console.WriteLine($"current node {node}");
                if (node.Value == value) return Backtrack(node, parents);

                if (node.HasLeft && !visitedNodes.Contains(node.Left))
                {
                    visitedNodes.Add(node.Left);
                    queue.Enqueue(node.Left);
                    parents[node.Left] = node;
                }

                if (node.HasRight && !visitedNodes.Contains(node.Right))
                {
                    visitedNodes.Add(node.Right);
                    queue.Enqueue(node.Right);
                    parents[node.Right] = node;
                }
            }

            return new List<IntNode>();
        }

        static List<IntNode> Backtrack(IntNode node, Dictionary<IntNode, IntNode> parents)
        {
            var path  = new List<IntNode>();
            path.Add(node);

            var parent = (IntNode)null;
            parents.TryGetValue(node, out parent);

            while (parent != null)
            {
                path.Add(parent);
                parents.TryGetValue(parent, out var newParent);
                parent = newParent;
            }

            return path;
        }




















        internal static List<int> FindNode2(int searchFor, Dictionary<int, List<int>> adjacencyList, int root)
        {
            var visited = new HashSet<int>();
            var nodesToVist = new Queue<int>();
            var parents = new Dictionary<int, int>();

            nodesToVist.Enqueue(root);

            while(nodesToVist.Any())
            {
                var node = nodesToVist.Dequeue();
                Console.WriteLine(node);
                visited.Add(node);

                if (node == searchFor) return Backtrack(node, parents);

                var nodesChildren = adjacencyList[node];

                foreach (var child in nodesChildren)
                {
                    if(!visited.Contains(child))
                    {
                        parents[child] = node;
                        nodesToVist.Enqueue(child);
                    }
                }

            }

            return new List<int>();
        }

        private static List<int> Backtrack(int node, Dictionary<int, int> parents)
        {
            var path = new List<int>();

            path.Add(node);
            var currentParent = parents[node];

            while (currentParent > 0)
            {
                path.Add(currentParent);

                var tmpParent = 0;
                if (parents.TryGetValue(currentParent, out tmpParent))
                {
                    currentParent = tmpParent;
                }
                else
                {
                    currentParent = 0;
                }
            }

            return path;
        }
    }
}
