using RedGateTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    public class MockCharacterReader : ICharacterReader
    {
        public int Position = 0;
        public string Content;

        public MockCharacterReader(string content)
        {
            Content = content;
        }

        public char GetNextChar()
        {
            if (Position >= Content.Length)
            {
                throw new System.IO.EndOfStreamException();
            }

            return Content[Position++];
        }

        public void Dispose()
        {
            //do nothing
        }
    }
}
