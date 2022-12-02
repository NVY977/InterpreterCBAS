using static Interpreter.Tokenizer;

namespace Interpreter
{
    public class SolveMultiplyAndDivision
    {
        public static int Parse(Context context)
        {
            var _context = context;
            var _stack = context.Tokens;
            var convertResult = ConvertTokenType.Parse(context);

            if (_stack.Count <= 0)
                return convertResult;

            Token token = _stack.Peek();
            if (token.Type == TokenType.Operator)
            {
                if (token.TokenString == "*")
                {
                    _stack.Pop();
                    return convertResult * Parse(_context);
                }
                else if (token.TokenString == "/")
                {
                    _stack.Pop();
                    return convertResult / Parse(_context);
                }
            }
            return convertResult;
        }
    }
}
