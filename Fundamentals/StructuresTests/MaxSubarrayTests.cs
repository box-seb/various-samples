using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structures;

namespace StructuresTests
{
    internal class MaxSubarrayTests
    {
        [Test]
        public void Test1()
        {
            var array = new[] { 1, 2, 3, 4 };

            var result = MaxSubarray.GetMax(array, 5);

            Assert.IsTrue(result.SequenceEqual(new[] { 1, 2, }));
        }
    }
}
