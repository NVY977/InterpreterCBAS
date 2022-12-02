using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public class Context
    {
        public Dictionary<string, int> Table;
        public Stack<Token> Tokens;

        public Context(IEnumerable<Token> tokens)
        {
            Tokens = new Stack<Token>(tokens.Reverse());
            Table = new Dictionary<string, int>();
        }
    }
}
