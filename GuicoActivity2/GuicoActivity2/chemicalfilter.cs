using System;

namespace Guico_ScenarioD
{
    // ChemicalFilter inherits WaterFilter (Inheritance)
    public class ChemicalFilter : WaterFilter
    {
        private double chemicalLevel;

        public double ChemicalLevel
        {
            get { return chemicalLevel; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Chemical level cannot be negative.");
                chemicalLevel = value;
            }
        }

        // Constructor using base()
        public ChemicalFilter(string id, double initialLevel)
            : base(id)
        {
            ChemicalLevel = initialLevel;
        }

        // Override ProcessWater (Polymorphism)
        public override void ProcessWater(double liters)
        {
            if (liters <= 0)
                throw new ArgumentException("Water must be greater than zero.");

            UsageCount++;
            TotalWaterProcessed += liters;

            ChemicalLevel -= liters * 0.02;

            if (ChemicalLevel < 10)
                Console.WriteLine($"Chemical Filter [{FilterID}] WARNING: Low chemical level!");

            Console.WriteLine($"Chemical Filter [{FilterID}] purified {liters} liters.");
        }

        public override double CalculateEfficiency()
        {
            double baseEfficiency = base.CalculateEfficiency();
            return baseEfficiency + (ChemicalLevel * 0.03);
        }
    }
}