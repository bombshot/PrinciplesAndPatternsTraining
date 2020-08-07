// This code works, but follows procedural approach
// Task: Convert it to Object Oriented approach and apply Composite pattern

using System;

namespace Solid_Master.Composite.Before
{
    internal class Expr
    {
        private readonly Expr _left;
        private readonly Expr _right;
        private readonly string _value;

        public Expr(Expr left, string value, Expr right)
        {
            _left = left;
            _value = value;
            _right = right;
        }

        public void GenCode()
        {
            if (_left == null && _right == null)
            {
                Console.WriteLine("ldc.i4.s " + _value);
            }
            else
            {
                // its an intermediate node 
                _left.GenCode();
                _right.GenCode();
                switch (_value)
                {
                    case "+":
                        Console.WriteLine("add");
                        break;
                    case "-":
                        Console.WriteLine("sub");
                        break;
                    case "*":
                        Console.WriteLine("mul");
                        break;
                    case "/":
                        Console.WriteLine("div");
                        break;
                    default:
                        Console.WriteLine("Not implemented yet!");
                        break;
                }
            }
        }
    }

    internal class CompositeMain
    {
        public static void Main()
        {
            // ((10 * 20) + 30)  
            var expr = new Expr(
                new Expr(
                    new Expr(null, "10", null), "*", new Expr(null, "20", null)),
                "+",
                new Expr(null, "30", null));
            expr.GenCode();
            Console.ReadLine();
        }
    }
}