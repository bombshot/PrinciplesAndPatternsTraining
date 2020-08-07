// The Interpreter object has an execution stack object; for every bytecode object, 
// the evaluation is done by calling Exec method on that object 

using System;
using System.Collections.Generic;
using System.Linq;

namespace Solid_Master.Command.After
{
    internal class Interpreter
    {
        public int Interpret(ByteCode[] byteCodes)
        {
            // local variable 
            Stack<int> evalStack = new Stack<int>();
            byteCodes.ToList().ForEach(byteCode => byteCode.Exec(evalStack));
            return evalStack.Pop();
        }
    }

    internal abstract class ByteCode
    {
        public abstract void Exec(Stack<int> evalStack);
        public abstract void UnExec(Stack<int> evalStack);
    }

    internal class LDCI4S : ByteCode
    {
        private readonly int _val;

        public LDCI4S(int arg)
        {
            _val = arg;
        }

        public override void UnExec(Stack<int> evalStack)
        {
            evalStack.Pop();
        }
        
        public override void Exec(Stack<int> evalStack)
        {
            evalStack.Push(_val);
        }
    }

    internal class ADD : ByteCode
    {
        private int _val1, _val2;
        public override void Exec(Stack<int> evalStack)
        {
            var lval = evalStack.Pop();
            _val1 = lval; 
            var rval = evalStack.Pop();
            _val2 = rval; 
            evalStack.Push(rval + lval);
        }
        
        public override void UnExec(Stack<int> evalStack)
        {
            evalStack.Pop();
            evalStack.Push(_val2);
            evalStack.Push(_val1);
        }
    }

    internal class CommandMain
    {
        public static void Main()
        {
            // ((10 + 20) + 30)
            ByteCode[] byteCodes = {new LDCI4S(0x0A), new LDCI4S(0x14), new ADD(), new LDCI4S(0x1E), new ADD()};
            var interpreter = new Interpreter();
            Console.WriteLine(interpreter.Interpret(byteCodes));
            Console.ReadLine();
        }
    }
}