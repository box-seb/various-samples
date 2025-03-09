using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class Dfs
    {
        public static Stack<IntNode> FindNode(int value, IntNode root)
        {
            var currentNode = root;
            var path = new Stack<IntNode>();
            var visitedNodes = new HashSet<IntNode>();

            path.Push(currentNode);
            while (currentNode != null)
            {
                Console.WriteLine($"{currentNode.Value}");


                if (currentNode == root && visitedNodes.Contains(currentNode.Left) && visitedNodes.Contains(currentNode.Right))
                {
                    break;
                }

                visitedNodes.Add(currentNode);

                if (currentNode.HasLeft && !visitedNodes.Contains(currentNode.Left))
                {
                    path.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else if (currentNode.HasRight && !visitedNodes.Contains(currentNode.Right))
                {
                    path.Push(currentNode);
                    currentNode = currentNode.Right;
                }
                else
                {
                    currentNode = path.Pop();
                }

                if (currentNode.Value == value) return path;
            }

            return new Stack<IntNode>();
        }

        public static IList<IntNode> FindNode2(int value, IntNode root)
        {
            var currentNode = root;
            var path = new Stack<IntNode>();
            var visitedNodes = new HashSet<IntNode>();

            while (currentNode != null)
            {
                Console.WriteLine($"{currentNode.Value}");
                visitedNodes.Add(currentNode);
                path.Push(currentNode);

                if (currentNode.Value == value) break;

                if (currentNode == root && visitedNodes.Contains(currentNode.Left) && visitedNodes.Contains(currentNode.Right))
                {
                    break;
                }

                if (currentNode.HasLeft && !visitedNodes.Contains(currentNode.Left))
                {
                    currentNode = currentNode.Left;
                }
                else if (currentNode.HasRight && !visitedNodes.Contains(currentNode.Right))
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    currentNode = path.Pop();
                    currentNode = path.Pop();
                }
            }

            return path.ToList();
        }

        internal static List<int> FindNode2(int vsearchFor, Dictionary<int, List<int>> adjacencyList, int root)
        {
            var visited = new HashSet<int>();
            var path = new Stack<int>();

            var currentNode = root;

            while(currentNode > 0)
            {
                Console.WriteLine(currentNode);
                visited.Add(currentNode);
                path.Push(currentNode);

                if (currentNode == vsearchFor) return path.ToList();

                if(currentNode == root)
                {
                    var rootChildren = adjacencyList[root];
                    if (rootChildren.All(visited.Contains)) return path.ToList();
                }

                var nodeChildren = adjacencyList[currentNode];

                var currentNodeChanged = false;
                foreach (var item in nodeChildren)
                {
                    if (!visited.Contains(item))
                    {
                        currentNode = item;
                        currentNodeChanged = true;
                        break;
                    }
                }

                if (!currentNodeChanged)
                {
                    currentNode = path.Pop();
                    currentNode = path.Pop();
                }

            }

            throw new NotImplementedException();
        }


        public static void Recursive(Dictionary<int, List<int>> adjacencyList, int node)
        {
            HashSet<int> visited = new HashSet<int>();

            RecursiveDfs(adjacencyList, node, visited);
        }

        static void RecursiveDfs(Dictionary<int, List<int>> adjacencyList, int node, HashSet<int> visited)
        {
            if (visited.Contains(node)) return;

            visited.Add(node);

            foreach (var item in adjacencyList[node])
            {
                RecursiveDfs(adjacencyList, node, visited);
            }
        }

        public static List<int> FindRecursive(Dictionary<int, List<int>> adjacencyList, int node)
        {
            HashSet<int> visited = new HashSet<int>();
            var state = new RecDfsSearch { SearchFor = 7 };

            FindRecursiveDfs(adjacencyList, node, visited, state);

            state.Result.Reverse();

            return state.Result;
        }

        static void FindRecursiveDfs(Dictionary<int, List<int>> adjacencyList, int node, HashSet<int> visited, RecDfsSearch state)
        {
            if (visited.Contains(node) || state.Found) return;
            state.Path.Push(node);
            System.Diagnostics.Debug.WriteLine(node);
            visited.Add(node);

            if(node == state.SearchFor)
            {
                state.Found = true;
                state.Result = state.Path.ToList();
                return;
            }

            foreach (var item in adjacencyList[node])
            {
                FindRecursiveDfs(adjacencyList, item, visited, state);
            }
            state.Path.Pop();
        }

        class RecDfsSearch
        {
            public int SearchFor;
            public Stack<int> Path = new Stack<int>();
            public List<int> Result = new List<int>();
            public bool Found;
        }

    }
}
