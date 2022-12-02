using System;
using System.Collections.Generic;
using static Interpreter.Tokenizer;

namespace Interpreter
{
    public class Solution
    {
        public static int Parse(Context context)
        {
            var _context = context;
            Stack<Token> stack = context.Tokens;
            int termResult = SolveMultiplyAndDivision.Parse(_context);

            if (stack.Count <= 0)
                return termResult;

            Token token = stack.Peek();
            if (token.Type == TokenType.Operator)
            {
                if (token.TokenString == "+")
                {
                    stack.Pop();
                    return termResult + Parse(_context);

                }
                else if (token.TokenString == "-")
                {
                    stack.Pop();
                    if (stack.Count > 1)
                    {
                        Token next = stack.Pop();
                        Token nextOperation = stack.Peek();
                        stack.Push(next);
                        bool isNextMultOperation = nextOperation.TokenString == "*" || nextOperation.TokenString == "/";
                        if ((next.Type == TokenType.Digit || next.Type == TokenType.Character) && !isNextMultOperation)
                        {
                            int result = termResult - ConvertTokenType.Parse(_context);
                            Token newToken = new Token(result.ToString(), TokenType.Digit);
                            stack.Push(newToken);
                            return Parse(_context);
                        }
                    }
                    return termResult - Parse(_context);
                }
            }
            return termResult;
        }
    }
}
