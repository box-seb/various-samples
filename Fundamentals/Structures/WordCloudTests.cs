using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
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
    }
}
