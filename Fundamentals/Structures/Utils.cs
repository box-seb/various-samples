using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    internal class Utils
    {
        public static void Print(IList<IntNode> collection)
        {
            var val = string.Join(",", collection);

            Console.WriteLine("Path is:" + val);
        }

        internal static void Print(List<int> dfs2)
        {
            var val = string.Join(",", dfs2);

            Console.WriteLine("Path is:" + val);
        }
    }
}
