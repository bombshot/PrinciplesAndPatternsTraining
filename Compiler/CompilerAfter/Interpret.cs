using System;

namespace Solid_Master.Composite.Interpreter.After
{
    internal abstract class Expr
    {
        public abstract int Interpret();
    }

    internal class Constant : Expr
    {
        private readonly int _val;

        public Constant(int arg)
        {
            _val = arg;
        }

        public override int Interpret()
        {
            return _val;
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

        public override int Interpret()
        {
            return _left.Interpret() + _right.Interpret();
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
            Console.WriteLine(expr.Interpret());
            Console.ReadLine();
        }
    }
}