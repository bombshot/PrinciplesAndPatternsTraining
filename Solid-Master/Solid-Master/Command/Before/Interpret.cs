// This code is implements a tiny interpreter for a couple of 
// bytecode instructions in CIL (Common Intermediate Language)
// This code is written in procedural style - refactor by applying 
// Object Oriented design principles (and optionally design patterns) 

using System;
using System.Collections.Generic;
using Solid_Master.Command.After;

namespace Solid_Master.Command.Before
{
    [Flags]
    internal enum BYTECODE : byte
    {
        LDCI4S = 0x10,
        MUL = 0x68,
        DIV = 0x6c,
        ADD = 0x60,
        SUB = 0x64
    }

    class Interpreter
    {
        private readonly Stack<int> ExecutionStack = new Stack<int>();

        public int Interpret(byte[] byteCodes)
        {
            var pc = 0;
            while (pc < byteCodes.Length)
                switch (byteCodes[pc++])
                {
                    case (byte)BYTECODE.ADD:
                        ExecutionStack.Push(ExecutionStack.Pop() + ExecutionStack.Pop());
                        break;
                    case (byte)BYTECODE.LDCI4S:
                        ExecutionStack.Push(byteCodes[pc++]);
                        break;
                }
            return ExecutionStack.Pop();
        }
    }

    class CommandMain
    {
        public static void Main()
        {
            // ((10 + 20) + 30)
            byte[] byteCodes =
            {
                (byte) BYTECODE.LDCI4S, 0x0A, (byte) BYTECODE.LDCI4S, 0x14, (byte) BYTECODE.ADD, (byte) BYTECODE.LDCI4S,
                0x1E, (byte) BYTECODE.ADD
            };
            var result = new Interpreter().Interpret(byteCodes);
            Console.WriteLine("Execution result is: {0}", result);
        }
    }
}