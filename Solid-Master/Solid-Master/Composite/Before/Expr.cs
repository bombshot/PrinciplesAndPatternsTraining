using System;

namespace Solid_Master.Composite.Before
{
    public class Expression
    {
        public static void Main(string[] args)
        {
            int a = 1, b = 2, c = 3, d = 4, e = 5, f = 6;
            int r = (a - (b / c)) + ((d % e) * f);
            Console.WriteLine(r);
        }
    }
}