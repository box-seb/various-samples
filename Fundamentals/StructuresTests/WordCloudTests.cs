using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Structures;

namespace StructuresTests
{
    public class WordCloudTests
    {
        [Test]
        public void PlaceWord()
        {
            WordCloud cloud = new WordCloud();
            cloud.PlaceWord(0, 1, 3, 1);

            Assert.IsTrue(true);
        }

        [Test]
        public void IsConflict()
        {
            WordCloud cloud = new WordCloud();
            cloud.PlaceWord(0, 1, 3, 1);

            var result = cloud.IsConflict(2, 1, 5, 1);

            Assert.IsTrue(result);
        }
    }
}
