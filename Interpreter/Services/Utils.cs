using System;


namespace Interpreter
{
    public class Utils
    {
        public static void CheckStack(Context context)
        {
            if (context.Tokens.Count <= 0)
            {
                throw new Exception("Stack is empty");
            }
        }

        public static Exception ThrowUnexpectedToken(Token token)
        {
            return new Exception("Illegal token: " + token.TokenString);
        }
    }
}
