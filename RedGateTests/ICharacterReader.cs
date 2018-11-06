using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedGateTests
{
    public interface ICharacterReader : IDisposable
    {
        char GetNextChar();
    }
}
