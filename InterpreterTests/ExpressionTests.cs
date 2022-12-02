using Interpreter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterTests
{
    [TestFixture]
    public class ExpressionTests
    {
        [TestCase("1+2", 3)]
        [TestCase("1-2", -1)]
        [TestCase("1-2+1", 0)]
        [TestCase("3*4-1", 11)]
        [TestCase("(1)", 1)]
        [TestCase("(1)-(1)", 0)]
        [TestCase("(2+3)*(5)", 25)]
        [TestCase("((1)*34-1)", 33)]
        [TestCase("a*a", 100)]
        [TestCase("a*a-a*3", 70)]
        [TestCase("a-a+0", 0)]
        [TestCase("10-(8*a)", -70)]
        [TestCase("(a)+(4-8)/(4)", 9)]
        [TestCase("2/2/2", 2)]
        [TestCase("2+2*10-2", 18)]
        public void TestExpression(string code, int expected)
        {
            var tokinizer = new Tokenizer();
            var tokens = tokinizer.Tokenize(code);
            var context = new Interpreter.Interpreter.Context(tokens);
            context.Variables["a"] = 10;
            Assert.AreEqual(expected, Expression.Parse(context));
        }
    }
}
