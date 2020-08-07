// This code targets two platforms: JVM and DOTNET
// This code uses strategy pattern 

using System;

namespace Solid_Master.Strategy.After
{
    internal abstract class Target
    {
        public abstract void GenCode(Constant constant);
        public abstract void GenCode(Plus plus);
        public abstract void GenCode(Mult mult);
    }

    internal class JvmTarget : Target
    {
        public override void GenCode(Constant constant)
        {
            Console.WriteLine("bipush " + constant.GetValue());
        }

        public override void GenCode(Plus plus)
        {
            Console.WriteLine("iadd");
        }

        public override void GenCode(Mult mult)
        {
            Console.WriteLine("imul");
        }
    }

    internal class DotNetTarget : Target
    {
        public override void GenCode(Constant constant)
        {
            Console.WriteLine("ldarg " + constant.GetValue());
        }

        public override void GenCode(Plus plus)
        {
            Console.WriteLine("add");
        }

        public override void GenCode(Mult mult)
        {
            Console.WriteLine("mul");
        }
    }

    internal abstract class Expr
    {
        protected static Target Target = new JvmTarget();

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

        public int GetValue()
        {
            return _val;
        }

        public override void GenCode()
        {
            Target.GenCode(this);
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
            Target.GenCode(this);
        }
    }

    internal class Mult : Expr
    {
        private readonly Expr _left;
        private readonly Expr _right;

        public Mult(Expr arg1, Expr arg2)
        {
            _left = arg1;
            _right = arg2;
        }

        public override void GenCode()
        {
            _left.GenCode();
            _right.GenCode();
            Target.GenCode(this);
        }
    }

    internal class StrategyMain
    {
        public static void Main()
        {
            Expr.SetTarget(new JvmTarget());
            // ((10 * 20) + 30)  
            Expr expr = new Plus(
                new Mult(
                    new Constant(10),
                    new Constant(20)),
                new Constant(30));
            expr.GenCode();
            Console.ReadLine();
        }
    }
}