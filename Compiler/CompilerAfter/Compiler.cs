using System;

namespace Solid_Master.Composite.Compiler.After
{
    internal abstract class ExprNode
    {
        public abstract void GenCode();
    }

    internal class Constant : ExprNode
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

    internal class BinaryExprNode : ExprNode
    {
        private readonly ExprNode _left;
        private readonly ExprNode _right;

        public BinaryExprNode(ExprNode arg1, ExprNode arg2)
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

    internal class Plus : BinaryExprNode
    {
        public Plus(ExprNode arg1, ExprNode arg2) : base(arg1, arg2)
        {
        }

        public ExprName Make(ExprNode arg1, ExprNode arg2)
        {
            return new Plus(arg1, arg2)
        }    
        
        public override void GenCode()
        {
            base.GenCode();
            Console.WriteLine("add");
        }
    }

    internal class Multiply : BinaryExprNode
    {
        public Multiply(ExprNode arg1, ExprNode arg2) : base(arg1, arg2)
        {
        }

        public override void GenCode()
        {
            base.GenCode();
            Console.WriteLine("mul");
        }
    }

    internal class CompositeMain
    {
        public static void Main()
        {
            // ((10 * 20) + 10)  
            ExprNode exprNode =  Plus.Make(
                new Multiply(
                    new Constant(10),
                    new Constant(20)),
                new Constant(30));
            exprNode.GenCode();
            Console.ReadLine();
        }
    }
}