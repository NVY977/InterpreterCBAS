using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public class Program
    {
        static void Main(string[] args)
        {
            var code = File.ReadAllText("../../Resources/Code.txt");
            Console.WriteLine(code);
            Interpreter interpreter = new Interpreter();
            interpreter.Interpret(code);
            Console.ReadLine();
        }
    }
}
