using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedgateAssessment;

namespace UnitTestProject
{
    [TestClass]
    public class WordFrequencyTests
    {
        [TestMethod]
        public void DoesInitialzie()
        {
            var wf = new WordFrequency("foo", 1);
            Assert.AreEqual("foo", wf.Word, "The Word property was not initialized properly");
            Assert.AreEqual(1, wf.Frequency, "The Frequency property was not initialized properly");
        }

        [TestMethod]
        public void TestToString()
        {
            var wf = new WordFrequency("foo", 1);
            Assert.AreEqual("foo - 1", wf.ToString(), "String representations are not equal");
        }

        [TestMethod]
        public void TestEquals()
        {
            var wf = new WordFrequency("foo", 1);
            var areEqual = wf.Equals(null);
            Assert.AreEqual(false, areEqual);

            areEqual = wf.Equals(new object());
            Assert.AreEqual(false, areEqual);

            areEqual = wf.Equals(wf);
            Assert.AreEqual(true, areEqual);

            var wf2 = new WordFrequency("foo", 1);
            areEqual = wf.Equals(wf2);
            Assert.AreEqual(true, areEqual);

            var wf3 = new WordFrequency("fo", 1);
            areEqual = wf.Equals(wf3);
            Assert.AreEqual(false, areEqual);

            var wf4 = new WordFrequency("foo", 2);
            areEqual = wf.Equals(wf4);
            Assert.AreEqual(false, areEqual);
        }

        [TestMethod]
        public void TestCompareTo()
        {
            var wf = new WordFrequency("foo", 1);
            var result = wf.CompareTo(wf);
            Assert.AreEqual(0, result);

            var wf2 = new WordFrequency("foo", 1);
            result = wf.CompareTo(wf2);
            Assert.AreEqual(0, result);

            var wf3 = new WordFrequency("faa", 1);
            result = wf.CompareTo(wf3);
            Assert.AreEqual(1, result);

            var wf4 = new WordFrequency("zzz", 1);
            result = wf.CompareTo(wf4);
            Assert.AreEqual(-1, result);

            var wf5 = new WordFrequency("foo", 2);
            result = wf.CompareTo(wf5);
            Assert.AreEqual(1, result);

            var wf6 = new WordFrequency("foo", -2);
            result = wf.CompareTo(wf6);
            Assert.AreEqual(-1, result);
        }
    }
}
