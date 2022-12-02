using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public static class Rules
    {
        static Rules()
        {
            Digit = "\\d+";
            Character = "[a-zA-Z_]+";
            Operators = new[] { "+", "-", "*", "/" };
            BoolOperations = new[] { "<", ">", "==", "!=" };
            Equal = "=";
            Brackets = new[] { "(", ")", "{", "}" };
            QuoteString = "\"(.*?)\"";
            Punctuation = new[] { ";", ",", ":"};
            Space = "[\n\r\t ]+";
            Functions = new[] { "cin", "cout" };
            Sintaxis = new[] { "for", "to", "if", "else" };
        }

        public static IEnumerable<string> GetAllRules()
        {
            var list = new List<string>();
            list.AddRange(Functions);
            list.AddRange(Sintaxis);
            list.Add(QuoteString);
            list.Add(Digit);
            list.Add(Character);
            list.AddRange(Operators);
            list.AddRange(BoolOperations);
            list.Add(Equal);
            list.AddRange(Brackets);
            list.AddRange(Punctuation);
            list.Add(Space);
            return list;
        }

        public static string Digit { get; }
        public static string Character { get; }
        public static string[] Operators { get; }
        public static string[] BoolOperations { get; }
        public static string Equal { get; }
        public static string[] Brackets { get; }
        public static string QuoteString { get; }
        public static string[] Punctuation { get; }
        public static string Space { get; }
        public static string[] Functions { get; }
        public static string[] Sintaxis { get; }
    }
}
