using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structures;

namespace StructuresTests
{
    public class QuickortTests
    {
        [Test]
        public void Test()
        {

            var array = new[] { 1, 5, 3, 2, 4 };
            QuickSort.Sort(array, 0, array.Length - 1);

            Assert.IsTrue(array.SequenceEqual(new[] { 1, 2, 3, 4, 5 }));
        }

        [Test]
        public void TestPartition()
        {

            var array = new[] { 1, 5, 3, 2, 4 };
            QuickSort.Partition(array, 0, 4);

            Assert.IsTrue(array.SequenceEqual(new[] { 1, 3, 2, 4, 5 }));
        }
    }
}
