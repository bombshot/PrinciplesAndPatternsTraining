// This code users Builder Pattern for creating expression trees 

using System;
using System.Collections.Generic;

namespace Solid_Master.FluentInterfaces.After
{
    internal abstract class Expr
    {
        public abstract void GenCode();

        public Expr Plus(int arg)
        {
            return new Addition(this, Constant.Make(arg));
        }

        public Expr MultipledBy(int arg)
        {
            return new Multiplication(this, Constant.Make(arg));
        }
    }

    internal class ExprBuilder
    {
        private Expr _expr;

        public ExprBuilder Const(int arg)
        {
            _expr = Constant.Make(arg);
            return this;
        }

        public ExprBuilder Plus(int arg)
        {
            _expr = new Addition(_expr, Constant.Make(arg));
            return this;
        }

        public ExprBuilder Mult(int arg)
        {
            _expr = new Multiplication(_expr, Constant.Make(arg));
            return this;
        }

        public Expr Build()
        {
            return _expr;
        }
    }

    internal class Constant : Expr
    {
        private static readonly Dictionary<int, Constant> Pool = new Dictionary<int, Constant>();
        private readonly int _val;

        private Constant(int val)
        {
            _val = val;
        }

        public static Constant Make(int arg)
        {
            if (!Pool.ContainsKey(arg)) Pool[arg] = new Constant(arg);
            return Pool[arg];
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

    internal class Addition : BinaryExpr
    {
        public Addition(Expr arg1, Expr arg2) : base(arg1, arg2)
        {
        }

        public static Expr Make(Expr left, Expr right)
        {
            return new Addition(left, right);
        }

        public override void GenCode()
        {
            base.GenCode();
            Console.WriteLine("add");
        }
    }

    internal class Multiplication : BinaryExpr
    {
        public Multiplication(Expr arg1, Expr arg2) : base(arg1, arg2)
        {
        }

        public static Expr Make(Expr left, Expr right)
        {
            return new Multiplication(left, right);
        }

        public override void GenCode()
        {
            base.GenCode();
            Console.WriteLine("mul");
        }
    }

    internal class BuilderMain
    {
        public static void Main()
        {
            // ((10 * 20) + 30)
            var expr =  Constant.Make(10).MultipledBy(20).Plus(30);  
            expr.GenCode();
            Console.ReadLine();
        }
    }
}