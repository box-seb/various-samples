using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structures;

namespace StructuresTests
{
    public class CircularBufferTests
    {
        [Test]
        public void TestAdd()
        {
            var b = new CircularBuffer(3);

            b.Add(1);
            b.Add(2);
            b.Add(3);
            var res = b.Add(4);

            Assert.IsTrue(res.SequenceEqual(new[] { 4, 2, 3 }));
        }

        [Test]
        public void TestGet()
        {
            var b = new CircularBuffer(3);

            b.Add(1);
            b.Add(2);
            b.Add(3);
            b.Add(4);

            var res = b.Get();
            Assert.IsTrue(res == 2);

            res = b.Get();
            Assert.IsTrue(res == 3);

            res = b.Get();
            Assert.IsTrue(res == 4);

            Assert.Throws<Exception>(() => b.Get());
        }
    }
}
