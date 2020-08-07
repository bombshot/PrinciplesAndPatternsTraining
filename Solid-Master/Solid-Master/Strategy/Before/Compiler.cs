// This code uses conditional checks (conditional-type checking code)
// Use strategy pattern by "replacing conditionals with runtime polymorphism" 

using System;

namespace Solid_Master.Strategy.Before
{
    internal enum Target
    {
        JVM,
        DOTNET
    }

    internal abstract class Expr
    {
        public static Target Target = Target.JVM;

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
            if (Target == Target.JVM) Console.WriteLine("bipush " + _val);
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
            Console.WriteLine(Target == Target.JVM ? "iadd" : "add");
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
            if (Target == Target.JVM) Console.WriteLine("isub");
            else Console.WriteLine("sub");
        }
    }

    internal class StrategyMain
    {
        public static void Main()
        {
            Expr.SetTarget(Target.DOTNET);
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