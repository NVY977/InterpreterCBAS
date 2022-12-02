using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Interpreter
{
    public class Tokenizer
    {
        public IEnumerable<Token> Tokenize(string code)
        {
            var allRules = Rules.GetAllRules();
            IEnumerable<Token> tokens = new List<Token>(); 
            string regexPattern = string.Join("|", allRules.Select(x =>
            {
                if ("()*+".Contains(x))
                {
                    return $"({@"\" + x})";
                }
                return $"({x})";
            }));
            MatchCollection regex = Regex.Matches(code, regexPattern, RegexOptions.Singleline);
            foreach (Match item in regex)
            {
                string token = item.Value;

                if (string.IsNullOrWhiteSpace(token))
                { 
                    yield return new Token(token, TokenType.Space); 
                    continue; 
                }
                if (Rules.Functions.Contains(token)) 
                {
                    yield return new Token(token, TokenType.Function); 
                    continue; 
                }
                if (Rules.Sintaxis.Contains(token)) 
                {
                    yield return new Token(token, TokenType.Sintaxis); 
                    continue; 
                }
                if (Regex.Match(token, Rules.QuoteString).Success) 
                { 
                    yield return new Token(token, TokenType.QuoteString); 
                    continue; 
                }
                if (Regex.Match(token, Rules.Digit).Success) 
                { 
                    yield return new Token(token, TokenType.Digit); 
                    continue; 
                }
                if (Regex.Match(token, Rules.Character).Success) 
                { 
                    yield return new Token(token, TokenType.Character); 
                    continue; 
                }
                if (Rules.Operators.Contains(token)) 
                { 
                    yield return new Token(token, TokenType.Operator); 
                    continue; 
                }
                if (Rules.BoolOperations.Contains(token)) 
                { 
                    yield return new Token(token, TokenType.BoolOperation); 
                    continue; 
                }
                if (Rules.Equal == token) 
                { 
                    yield return new Token(token, TokenType.Equal); 
                    continue; 
                }
                if (Rules.Brackets.Contains(token)) 
                { 
                    yield return new Token(token, TokenType.Bracket); 
                    continue; 
                }
                if (Rules.Punctuation.Contains(token)) 
                { 
                    yield return new Token(token, TokenType.Punctuation); 
                    continue; 
                }
            }
        }
    }
}
