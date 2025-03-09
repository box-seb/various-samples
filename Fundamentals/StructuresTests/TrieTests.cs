using Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuresTests
{
    internal class TrieTests
    {
        [Test]
        public void Test()
        {
            var word = "ice";
            var word2 = "test";
            var word3 = "tent";
            var word4 = "tense";

            var t = new Trie();
            t.Insert(word);
            t.Insert(word2);
            t.Insert(word3);
            t.Insert(word4);

            var words = t.GetWords();

            var startsWith = t.StartsWith("ten");

            Assert.IsTrue(words.Contains(word));
        }
    }
}
