using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class MockCharacterReaderTests
    {
        [TestMethod]
        public void ThrowsExceptionOnEnd()
        {
            var reader = new MockCharacterReader(string.Empty);
            Assert.ThrowsException<System.IO.EndOfStreamException>(() => reader.GetNextChar());
        }

        [TestMethod]
        public void ReadsTillTheEnd()
        {
            var reader = new MockCharacterReader(@"a .-
_/");
            var character = reader.GetNextChar();
            Assert.AreEqual('a', character);

            character = reader.GetNextChar();
            Assert.AreEqual(' ', character);

            character = reader.GetNextChar();
            Assert.AreEqual('.', character);

            character = reader.GetNextChar();
            Assert.AreEqual('-', character);

            character = reader.GetNextChar();
            Assert.AreEqual('\r', character);

            character = reader.GetNextChar();
            Assert.AreEqual('\n', character);

            character = reader.GetNextChar();
            Assert.AreEqual('_', character);

            character = reader.GetNextChar();
            Assert.AreEqual('/', character);

            Assert.ThrowsException<System.IO.EndOfStreamException>(() => reader.GetNextChar());
        }
    }
}
