using System;

namespace Guico_ScenarioD
{
    // ABSTRACT BASE CLASS
    public abstract class WaterFilter
    {
        // Private fields (Encapsulation)
        private string filterID;
        private int usageCount;
        private double totalWaterProcessed;

        // Public property with validation
        public string FilterID
        {
            get { return filterID; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Filter ID cannot be empty.");
                filterID = value;
            }
        }

        public int UsageCount
        {
            get { return usageCount; }
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Usage count cannot be negative.");
                usageCount = value;
            }
        }

        public double TotalWaterProcessed
        {
            get { return totalWaterProcessed; }
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Water processed cannot be negative.");
                totalWaterProcessed = value;
            }
        }

        // Constructor
        public WaterFilter(string id)
        {
            FilterID = id;
            UsageCount = 0;
            TotalWaterProcessed = 0;
        }

        // Abstract method (Abstraction)
        public abstract void ProcessWater(double liters);

        // Virtual method (Polymorphism)
        public virtual double CalculateEfficiency()
        {
            if (UsageCount == 0)
                throw new DivideByZeroException("Cannot calculate efficiency without usage.");

            return TotalWaterProcessed / UsageCount;
        }
    }
}