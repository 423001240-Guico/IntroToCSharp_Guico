using System;

namespace Guico_ScenarioD
{
    // CarbonFilter inherits WaterFilter (Inheritance)
    public class CarbonFilter : WaterFilter
    {
        private double debrisCaptured;

        public double DebrisCaptured
        {
            get { return debrisCaptured; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Debris cannot be negative.");
                debrisCaptured = value;
            }
        }

        // Constructor using base()
        public CarbonFilter(string id, double initialDebris)
            : base(id)
        {
            DebrisCaptured = initialDebris;
        }

        // Override ProcessWater (Polymorphism)
        public override void ProcessWater(double liters)
        {
            if (liters <= 0)
                throw new ArgumentException("Water must be greater than zero.");

            UsageCount++;
            TotalWaterProcessed += liters;

            DebrisCaptured += liters * 0.15;

            Console.WriteLine($"Carbon Filter [{FilterID}] cleaned {liters} liters.");
        }

        public override double CalculateEfficiency()
        {
            double baseEfficiency = base.CalculateEfficiency();
            return baseEfficiency + (DebrisCaptured * 0.05);
        }
    }
}