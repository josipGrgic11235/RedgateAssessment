using System;

namespace RedGateTests
{
    public interface ICharacterReader : IDisposable
    {
        char GetNextChar();
    }
}
