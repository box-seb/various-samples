using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuresTests
{
    internal class ArythmeticEquationTests
    {
        [Test]
        public void Test()
        {
            var input = "3+2*5+1";

            var result = Structures.ArythmeticEquation.Calculate3(input);

            Assert.IsTrue(result == 14);
        }

        [Test]
        public void Test2()
        {
            var input = "3*2*5*1";

            var result = Structures.ArythmeticEquation.Calculate3(input);

            Assert.IsTrue(result == 30);
        }
    }
}
