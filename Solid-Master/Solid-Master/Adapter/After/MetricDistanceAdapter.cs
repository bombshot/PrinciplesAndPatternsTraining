using System;

namespace Solid_Master.Adapter.After
{
    abstract class Distance
    {
        private readonly double _unit;

        protected Distance(double unit)
        {
            _unit = unit;
        }

        public abstract void Display();
    }

    class MetricDistanceAdapter : Distance
    {
        private readonly ImperialDistance _distance;

        public override void Display()
        {
            Console.WriteLine($"Distance is {_distance.Unit * 1.6} miles");
        }

        public MetricDistanceAdapter(double unit, ImperialDistance distance) : base(distance.Unit)
        {
            _distance = distance;
        }
    }

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
}
