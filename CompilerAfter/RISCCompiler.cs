using System;

namespace Solid_Master.Composite.After
{
    internal class Register
    {
        private readonly int _index;

        private Register(int index)
        {
            _index = index;
        }

        public static Register GetRegister(int index)
        {
            return new Register(index);
        }

        public int GetIndex()
        {
            return _index;
        }
    }

    internal class RegisterAllocator
    {
        private static int _registerIndex;

        public static Register GetNextRegister()
        {
            return Register.GetRegister(_registerIndex++);
        }
    }

    internal abstract class Expr
    {
        public abstract Register GenCode();
    }

    internal class Constant : Expr
    {
        private readonly int _val;

        public Constant(int arg)
        {
            _val = arg;
        }

        public override Register GenCode()
        {
            var targetRegister = RegisterAllocator.GetNextRegister();
            Console.WriteLine("mov r{0}, {1}", targetRegister.GetIndex(), _val);
            return targetRegister;
        }
    }

    internal class Plus : Expr
    {
        private readonly Expr _left;
        private readonly Expr _right;

        public Plus(Expr arg1, Expr arg2)
        {
            _left = arg1;
            _right = arg2;
        }

        public override Register GenCode()
        {
            var firstRegister = _left.GenCode();
            var secondRegister = _right.GenCode();
            var targetRegister = RegisterAllocator.GetNextRegister();
            Console.WriteLine("add r{0}, r{1}, r{2}", targetRegister.GetIndex(), firstRegister.GetIndex(),
                secondRegister.GetIndex());
            return targetRegister;
        }
    }

    internal class CompositeMain
    {
        public static void Main()
        {
            // ((10 + 20) + 30)  
            Expr expr = new Plus(
                new Plus(
                    new Constant(10),
                    new Constant(20)),
                new Constant(30));
            expr.GenCode();
            Console.ReadLine();
        }
    }
}