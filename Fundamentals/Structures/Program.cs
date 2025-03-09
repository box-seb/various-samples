// See https://aka.ms/new-console-template for more information
using Structures;
using System.Xml;

Console.WriteLine("Hello, World!");


// Arrays and lists, binary trees, hash tables, stacks and queues, basic graph representations; an understanding of data structure fundamentals like pointers (as if you weren't using an object-oriented language)



Console.WriteLine("queue");
Queue<int> queue = new Queue<int>();
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);

while (queue.Count > 0)
{
    Console.WriteLine(queue.Dequeue());
}

Console.WriteLine();
Console.WriteLine("stack");
Stack<int> stack = new Stack<int>();
stack.Push(1);
stack.Push(2);
stack.Push(3);

while (stack.Count > 0)
{
    Console.WriteLine(stack.Pop());
}

Console.WriteLine();
Console.WriteLine("hash");

HashSet<int> set = new HashSet<int>();
set.Add(1);
set.Add(2);
set.Add(3);

//while (set.Count > 0)
//{
//    if(set.Contains(1))
//    {
//        Console.WriteLine("Contains 1");
//    }
//}


Console.WriteLine();
Console.WriteLine("Binary tree");

var root = new IntNode
{
    Value = 1,
    Left = new IntNode
    {
        Value = 2,
        Left = new IntNode { Value = 3 },
        Right = new IntNode
        {
            Value = 5,
            Right = new IntNode { Value = 7 },
        }
    },
    Right = new IntNode
    {
        Value = 9,
        Right = new IntNode 
        { 
            Value = 11,
            Right = new IntNode { Value = 12 }, 
        },
    },
};

var pathToValue = Dfs.FindNode2(7, root);
Utils.Print(pathToValue);

var bfsResult = Bfs.FindNode(7, root);
Utils.Print(bfsResult);

var adjacencyList = new Dictionary<int, List<int>>();
adjacencyList.Add(1, new List<int> { 2, 9 });
adjacencyList.Add(2, new List<int> { 3, 5 });
adjacencyList.Add(3, new List<int> { });
adjacencyList.Add(5, new List<int> { 7 });
adjacencyList.Add(7, new List<int> { });
adjacencyList.Add(9, new List<int> { 11 });
adjacencyList.Add(11, new List<int> { 12 });
adjacencyList.Add(12, new List<int> { });

Console.WriteLine("DFS 2");
var dfs2 = Dfs.FindNode2(7, adjacencyList, 1);
Utils.Print(dfs2);

Console.WriteLine("BFS 2");
var bfs2 = Bfs.FindNode2(7, adjacencyList, 1);
Utils.Print(dfs2);

Console.WriteLine("Enter to close ...");
Console.ReadLine();
