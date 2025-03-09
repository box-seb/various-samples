using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class TrieNode
    {
        public char Value;
        public bool IsWordEnd;
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();

        public override string ToString()
        {
            return Value.ToString();
        }
    }


    public class Trie
    {
        TrieNode root = new TrieNode();

        public List<string> GetWords()
        {
            List<string> words = new List<string>();
            HashSet<TrieNode> visited = new HashSet<TrieNode>();
            Stack<TrieNode> stack = new Stack<TrieNode>();

            var node = root;

            while (node != null)
            {
                visited.Add(node);
                stack.Push(node);

                if (node == root && root.Children.Values.All(visited.Contains)) return words;

                if (node.IsWordEnd)
                {
                    words.Add(string.Join("", stack.ToList().Select(x => x.Value).Reverse().Skip(1)));
                }

                var nodeAssigned = false;
                foreach (var child in node.Children)
                {
                    if (!visited.Contains(child.Value))
                    {
                        node = child.Value;
                        nodeAssigned = true;
                        break;
                    }
                }

                if (nodeAssigned == false)
                {
                    node = stack.Pop();
                    node = stack.Pop();
                }
            }


            return words;
        }

        public void Insert(string word)
        {
            var node = root;

            foreach (var item in word)
            {
                if (node.Children.ContainsKey(item))
                {
                    node = node.Children[item];
                }
                else
                {
                    var n = new TrieNode { Value = item };
                    node.Children.Add(item, n);
                    node = n;
                }
            }

            node.IsWordEnd = true;
        }

        public bool Search(string word)
        {
            return false;
        }

        public List<string> StartsWith(string word)
        {
            List<string> words = new List<string>();
            HashSet<TrieNode> visited = new HashSet<TrieNode>();
            Stack<TrieNode> stack = new Stack<TrieNode>();

            var node = root;

            while (node != null)
            {
                visited.Add(node);
                stack.Push(node);

                var level = stack.Count - 1;

                if (node == root)
                {
                    if (root.Children.ContainsKey(word[level]))
                    {
                        if (visited.Contains(root.Children[word[level]]))
                        {
                            return words;
                        }
                    }
                    else
                    {
                        return words;
                    }
                }

                if (node.IsWordEnd)
                {
                    words.Add(string.Join("", stack.ToList().Select(x => x.Value).Reverse().Skip(1)));
                }

                var nodeAssigned = false;

                if (level < word.Length)
                {
                    if (node.Children.ContainsKey(word[level]))
                    {
                        var tmpNode = node.Children[word[level]];
                        if (!visited.Contains(tmpNode))
                        {
                            node = tmpNode;
                            visited.Add(node);
                            nodeAssigned = true;
                        }
                    }
                }
                else
                {
                    foreach (var child in node.Children)
                    {
                        if(!visited.Contains(child.Value))
                        {
                            node = child.Value; ;
                            visited.Add(node);
                            nodeAssigned = true;
                            break;
                        }
                    }
                }

                if (nodeAssigned == false)
                {
                    node = stack.Pop();
                    node = stack.Pop();
                }
            }


            return words;
        }
    }
}
