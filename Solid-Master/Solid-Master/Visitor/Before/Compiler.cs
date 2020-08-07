// This code uses conditional checks (conditional-type checking code)
// Use visitor pattern to cleanly separate the domain logic from 
// code generation logic 

using System;

namespace Solid_Master.Visitor.Before
{
    internal enum Target
    {
        Jvm,
        Dotnet
    }

    internal abstract class Expr
    {
        public static Target Target = Target.Jvm;

        public static void SetTarget(Target target)
        {
            Target = target;
        }

        public abstract void GenCode();
    }

    internal class Constant : Expr
    {
        private readonly int _val;

        public Constant(int arg)
        {
            _val = arg;
        }

        public override void GenCode()
        {
            if (Target == Target.Jvm) Console.WriteLine("bipush " + _val);
            else Console.WriteLine("ldc.i4.s " + _val);
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

        public override void GenCode()
        {
            _left.GenCode();
            _right.GenCode();
            if (Target == Target.Jvm) Console.WriteLine("iadd");
            else Console.WriteLine("add");
        }
    }

    internal class Sub : Expr
    {
        private readonly Expr _left;
        private readonly Expr _right;

        public Sub(Expr arg1, Expr arg2)
        {
            _left = arg1;
            _right = arg2;
        }

        public override void GenCode()
        {
            _left.GenCode();
            _right.GenCode();
            if (Target == Target.Jvm) Console.WriteLine("isub");
            else Console.WriteLine("sub");
        }
    }

    internal class VisitorMain
    {
        public static void Main()
        {
            Expr.SetTarget(Target.Dotnet);
            // (10 + (20 - 30))  
            Expr expr = new Plus(
                new Constant(10),
                new Sub(
                    new Constant(20),
                    new Constant(30)));
            expr.GenCode();
            Console.ReadLine();
        }
    }
}