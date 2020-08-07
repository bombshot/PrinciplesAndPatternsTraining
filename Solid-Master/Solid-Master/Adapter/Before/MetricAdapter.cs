using System;

namespace Solid_Master.Adapter.Before
{
    class ImperialDistance
    {
        private readonly double _unit;

        public ImperialDistance(double unit)
        {
            _unit = unit;
        }

        public double Unit => _unit;

        public override string ToString()
        {
            return $"Distance is {Unit} Kms";
        }
    }

    public static class AdapterMain
    {
        public static void Main()
        {
            ImperialDistance distance = new ImperialDistance(10);
            Console.WriteLine(distance.ToString());

            //Now display in metric
            Console.WriteLine($"Distance is {distance.Unit * 1.6} miles");
        }
    }
}
