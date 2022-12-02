using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public class Token
    {
        public string TokenString { get; }
        public TokenType Type { get; }

        public Token(string token, TokenType identity)
        {
            TokenString = token;
            Type = identity;
        }
    }
}
