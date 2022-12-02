using System;
using static Interpreter.Tokenizer;

namespace Interpreter
{
    public class ConvertTokenType
    {
        public static int Parse(Context context)
        {
            var _context = context;
            var stack = context.Tokens;
            var table = context.Table;
            Token token = stack.Pop();
            TokenType _type = token.Type;
            string tokenString = token.TokenString;
            if (_type == TokenType.Digit)
            {
                return Convert.ToInt32(tokenString);
            }

            if (_type == TokenType.Character)
            {
                var isInTable = table.ContainsKey(tokenString);
                if (!isInTable)
                {
                    throw new Exception("Illegal token" + token.TokenString);
                }
                return table[tokenString];
            }

            if (_type == TokenType.Bracket && tokenString == "(")
            {
                var result = Solution.Parse(_context);
                Utils.CheckStack(_context);
                var closeBracket = stack.Pop();
                if (closeBracket.TokenString == ")")
                {
                    return result;
                }
            }
            throw new Exception("Illegal symbol" + tokenString);
        }
    }
}
