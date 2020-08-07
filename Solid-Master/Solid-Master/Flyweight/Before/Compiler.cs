// This code uses constructor for the node objects in the expression tree
// Instead, refactor this code to introduce factory methods 

using System;

namespace Solid_Master.Flyweight.Before
{
    internal abstract class Expr
    {
        public abstract void GenCode();
    }

    internal class Constant : Expr
    {
        private readonly int _val;

        public Constant(int val)
        {
            _val = val;
        }

        public override void GenCode()
        {
            Console.WriteLine("ldc.i4.s " + _val);
        }
    }

    internal class BinaryExpr : Expr
    {
        private readonly Expr _left;
        private readonly Expr _right;

        public BinaryExpr(Expr arg1, Expr arg2)
        {
            _left = arg1;
            _right = arg2;
        }

        public override void GenCode()
        {
            _left.GenCode();
            _right.GenCode();
        }
    }

    internal class Plus : BinaryExpr
    {
        public Plus(Expr arg1, Expr arg2) : base(arg1, arg2)
        {
        }

        public override void GenCode()
        {
            base.GenCode();
            Console.WriteLine("add");
        }
    }

    internal class Multiply : BinaryExpr
    {
        public Multiply(Expr arg1, Expr arg2) : base(arg1, arg2)
        {
        }

        public override void GenCode()
        {
            base.GenCode();
            Console.WriteLine("mul");
        }
    }

    internal class FlyweightMain
    {
        public static void Main()
        {
            // ((10 * 20) + 10)  
            Expr expr = new Plus(
                new Multiply(
                    new Constant(10),
                    new Constant(20)),
                new Constant(30));
            expr.GenCode();
            Console.ReadLine();
        }
    }
}