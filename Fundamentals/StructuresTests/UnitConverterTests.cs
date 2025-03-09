using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structures;

namespace StructuresTests
{
    internal class UnitConverterTests
    {
        [Test]
        public void ConvertMegaToKilo()
        {
            double mega = 5;

            var result = UnitConverter.Calculate(mega, "mega", "kilo");

            Assert.IsTrue(result == 5000);
        }

        [Test]
        public void ConvertKiloToMega()
        {
            double kilo = 50000;

            var result = UnitConverter.Calculate(kilo, "kilo", "mega");

            Assert.IsTrue(result == 50);
        }

        [Test]
        public void ConvertMiliToBase()
        {
            double value = 50000;

            var result = UnitConverter.Calculate(value, "mili", "base");

            Assert.IsTrue(result == 50);
        }

        [Test]
        public void ConvertMicroToBase()
        {
            double value = 50000000;

            var result = UnitConverter.Calculate(value, "micro", "base");

            Assert.IsTrue(result == 50);
        }

        [Test]
        public void ConvertMicroToMili()
        {
            double value = 50_000_000;

            var result = UnitConverter.Calculate(value, "micro", "mili");

            Assert.IsTrue(result == 50000);
        }

        [Test]
        public void ConvertMegaToMili()
        {
            double value = 50;

            var result = UnitConverter.Calculate(value, "mega", "mili");

            Assert.IsTrue(result == 50000);
        }
    }
}
