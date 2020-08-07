using System;
using System.Collections.Generic;
using System.Linq;

namespace Solid_Master.Iterator.After
{
    public abstract class Expr
    {
        public abstract void GenCode();

        public virtual Expr GetLeft()
        {
            return null;
        }

        public virtual Expr GetRight()
        {
            return null;
        }
    }

    internal class ExprIterator
    {
        public static IEnumerable<Expr> Traverse(Expr node)
        {
            if (node != null)
            {
                foreach (var left in Traverse(node.GetLeft())) yield return left;
                foreach (var right in Traverse(node.GetRight())) yield return right;
                yield return node;
            }
        }
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

    internal abstract class BinaryExpr : Expr
    {
        private readonly Expr _left;
        private readonly Expr _right;

        public BinaryExpr(Expr arg1, Expr arg2)
        {
            _left = arg1;
            _right = arg2;
        }

        public override Expr GetLeft()
        {
            return _left;
        }

        public override Expr GetRight()
        {
            return _right;
        }
    }

    internal class Plus : BinaryExpr
    {
        public Plus(Expr arg1, Expr arg2) : base(arg1, arg2)
        {
        }

        public override void GenCode()
        {
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
            Console.WriteLine("mul");
        }
    }

    internal class IteratorMain
    {
        public static void Main()
        {
            // ((10 * 20) + 30)  
            Expr expr = new Plus(
                new Multiply(
                    new Constant(10),
                    new Constant(20)),
                new Constant(30)
            );


            var iterator = ExprIterator.Traverse(expr);

            foreach (var node in iterator) node.GenCode();

            
            Console.ReadLine();
        }
    }
}