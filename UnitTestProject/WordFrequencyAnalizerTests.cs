using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedgateAssessment;

namespace UnitTestProject
{
    [TestClass]
    public class WordFrequencyAnalizerTests
    {
        [TestMethod]
        public void TestSorting()
        {
            var reader = new MockCharacterReader("a b b c c c d d d d e e e e");
            var analizer = new WordFrequencyAnalizer(reader);
            var output = analizer.Analize();
            var expected = new List<WordFrequency>{
                new WordFrequency("d", 4),
                new WordFrequency("e", 4),
                new WordFrequency("c", 3),
                new WordFrequency("b", 2),
                new WordFrequency("a", 1),
            };

            CollectionAssert.AreEqual(expected, output, "Sorting does not satisfy requirements");
        }

        [TestMethod]
        public void TestStringFromPdf()
        {
            var reader = new MockCharacterReader("It was the best of times, it was the worst of times");
            var analizer = new WordFrequencyAnalizer(reader);
            var output = analizer.Analize();
            var expected = new List<WordFrequency>{
                new WordFrequency("it", 2),
                new WordFrequency("of", 2),
                new WordFrequency("the", 2),
                new WordFrequency("times", 2),
                new WordFrequency("was", 2),
                new WordFrequency("best", 1),
                new WordFrequency("worst", 1),
            };

            CollectionAssert.AreEqual(expected, output, "Sorting does not satisfy requirements");
        }

        [TestMethod]
        public void TestUniqueItems()
        {
            var reader = new MockCharacterReader("a b b c c c d d d d e e e e");
            var analizer = new WordFrequencyAnalizer(reader);
            var output = analizer.Analize();

            CollectionAssert.AllItemsAreUnique(output, "All words in collection are not unique");
        }

        [TestMethod]
        public void TestConsumeWordMethod_Basic()
        {
            var reader = new MockCharacterReader("a");
            var analizer = new WordFrequencyAnalizer(reader);

            var word = analizer.ConsumeWord();
            Assert.AreEqual("a", word, $"Consumed word not equal to the expected one. Expected a, Got: {word}");
        }

        [TestMethod]
        public void TestConsumeWordMethod_GarbageOnStartOfWord()
        {
            // single character
            var reader = new MockCharacterReader(".a");
            var analizer = new WordFrequencyAnalizer(reader);

            var word = analizer.ConsumeWord();
            Assert.AreEqual("a", word, $"Consumed word not equal to the expected one. Expected: a, Got: {word}");

            // multiple characters
            reader = new MockCharacterReader(". '--a");
            analizer = new WordFrequencyAnalizer(reader);

            word = analizer.ConsumeWord();
            Assert.AreEqual("a", word, $"Consumed word not equal to the expected one. Expected: a, Got: {word}");
        }

        [TestMethod]
        public void TestConsumeWordMethod_GarbageOnEndOfWord()
        {
            // single character
            var reader = new MockCharacterReader("a.");
            var analizer = new WordFrequencyAnalizer(reader);

            var word = analizer.ConsumeWord();
            Assert.AreEqual("a", word, $"Consumed word not equal to the expected one. Expected: a, Got: {word}");

            // multiple characters
            reader = new MockCharacterReader("a. --");
            analizer = new WordFrequencyAnalizer(reader);

            word = analizer.ConsumeWord();
            Assert.AreEqual("a", word, $"Consumed word not equal to the expected one. Expected: a, Got: {word}");
        }

        [TestMethod]
        public void TestConsumeWordMethod_GarbageOnStartAndEndOfWord()
        {
            // single character
            var reader = new MockCharacterReader(".a.");
            var analizer = new WordFrequencyAnalizer(reader);

            var word = analizer.ConsumeWord();
            Assert.AreEqual("a", word, $"Consumed word not equal to the expected one. Expected: a, Got: {word}");

            // multiple characters
            reader = new MockCharacterReader(". '--a. 47!&%");
            analizer = new WordFrequencyAnalizer(reader);

            word = analizer.ConsumeWord();
            Assert.AreEqual("a", word, $"Consumed word not equal to the expected one. Expected: a, Got: {word}");
        }

        [TestMethod]
        public void TestConsumeWordMethod()
        {
            var reader = new MockCharacterReader(@"a ,-'#/471b /*-51''b47
9161!# $%&/()=4486

5161");
            var analizer = new WordFrequencyAnalizer(reader);

            var word = analizer.ConsumeWord();
            Assert.AreEqual("a", word, $"Consumed word not equal to the expected one. Expected: a, Got: {word}");

            word = analizer.ConsumeWord();
            Assert.AreEqual("b", word, $"Consumed word not equal to the expected one. Expected: b, Got: {word}");

            word = analizer.ConsumeWord();
            Assert.AreEqual("b", word, $"Consumed word not equal to the expected one. Expected: b, Got: {word}");

            word = analizer.ConsumeWord();
            Assert.AreEqual(string.Empty, word, $"Consumed word not equal to the expected one. Expected: null, Got: {word}");

            word = analizer.ConsumeWord();
            Assert.AreEqual(string.Empty, word, $"Consumed word not equal to the expected one. Expected: null, Got: {word}");
        }
    }
}
