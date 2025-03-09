using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Structures;


namespace StructuresTests
{
    public class DfsTests
    {
        [Test]
        public void Test()
        {
            var graph = GetGraph();

            var result = Dfs.FindRecursive(graph, 1);
            
            Assert.True(result.SequenceEqual(new[] { 1, 2, 5, 7 }));
        }

        static Dictionary<int, List<int>> GetGraph()
        {
            var adjacencyList = new Dictionary<int, List<int>>();
            adjacencyList.Add(1, new List<int> { 2, 9 });
            adjacencyList.Add(2, new List<int> { 3, 5 });
            adjacencyList.Add(3, new List<int> { });
            adjacencyList.Add(5, new List<int> { 7 });
            adjacencyList.Add(7, new List<int> { });
            adjacencyList.Add(9, new List<int> { 11 });
            adjacencyList.Add(11, new List<int> { 12 });
            adjacencyList.Add(12, new List<int> { });

            return adjacencyList;
        }
    }
}
