/*
===============================================================
Codac Logistics - Driver Fuel & Performance Analyzer
Author: [Your Name]
Course: [Your Course]
Description:
This console application records a driver's weekly fuel activity,
validates distance input, stores 5-day fuel expenses in an array,
calculates efficiency metrics, and generates a structured audit report.

Concepts Demonstrated:
- string, int, double, decimal, bool
- Console input/output
- while loop validation
- 1D decimal array
- for loop iteration
- if/else decision logic
- string interpolation
===============================================================
*/

using System;

class FuelAuditSystem
{
    static void Main(string[] args)
    {
        Console.WriteLine("==== CODAC LOGISTICS DRIVER AUDIT TOOL ====\n");

        // ====================================================
        // TASK 1: DRIVER PROFILE & DISTANCE VALIDATION
        // ====================================================

        // string is used because a name is textual data
        Console.Write("Enter Driver Full Name: ");
        string fullName = Console.ReadLine();

        // decimal is used for money to prevent rounding errors
        Console.Write("Enter Weekly Fuel Budget: ");
        decimal weeklyBudget = decimal.Parse(Console.ReadLine());

        // double is used because distance may contain decimals
        double weeklyDistance = 0;

        // while loop ensures valid range (1 - 5000 km)
        while (weeklyDistance < 1.0 || weeklyDistance > 5000.0)
        {
            Console.Write("Enter Total Distance Traveled This Week (1 - 5000 km): ");
            weeklyDistance = double.Parse(Console.ReadLine());

            if (weeklyDistance < 1.0 || weeklyDistance > 5000.0)
            {
                Console.WriteLine("⚠ Invalid input. Distance must be between 1 and 5000 km.\n");
            }
        }

        // ====================================================
        // TASK 2: FUEL EXPENSE TRACKING (5 DAYS)
        // ====================================================

        // 1D array to store exactly 5 daily expenses
        decimal[] fuelExpenses = new decimal[5];

        decimal totalFuelCost = 0;

        // for loop is appropriate because number of days is fixed (5)
        for (int day = 0; day < fuelExpenses.Length; day++)
        {
            Console.Write($"Enter fuel cost for Day {day + 1}: ");
            fuelExpenses[day] = decimal.Parse(Console.ReadLine());

            // accumulate running total
            totalFuelCost += fuelExpenses[day];
        }

        // ====================================================
        // TASK 3: PERFORMANCE ANALYSIS
        // ====================================================

        // average calculation
        decimal averageCost = totalFuelCost / fuelExpenses.Length;

        // efficiency calculation (distance divided by total fuel cost)
        double efficiencyScore = weeklyDistance / (double)totalFuelCost;

        string efficiencyLabel;

        // classification using if/else
        if (efficiencyScore > 15)
        {
            efficiencyLabel = "High Efficiency";
        }
        else if (efficiencyScore >= 10)
        {
            efficiencyLabel = "Standard Efficiency";
        }
        else
        {
            efficiencyLabel = "Low Efficiency / Maintenance Required";
        }

        // bool type used for true/false budget result
        bool isWithinBudget = totalFuelCost <= weeklyBudget;

        // ====================================================
        // TASK 4: FINAL AUDIT REPORT
        // ====================================================

        Console.WriteLine("\n==============================================");
        Console.WriteLine("           WEEKLY DRIVER AUDIT REPORT         ");
        Console.WriteLine("==============================================");

        Console.WriteLine($"Driver Name: {fullName}");
        Console.WriteLine($"Total Distance Covered: {weeklyDistance} km\n");

        Console.WriteLine("---- 5 Day Fuel Expense Breakdown ----");

        for (int day = 0; day < fuelExpenses.Length; day++)
        {
            Console.WriteLine($"Day {day + 1}: {fuelExpenses[day]:C}");
        }

        Console.WriteLine("\n---- Financial Summary ----");
        Console.WriteLine($"Total Fuel Spent: {totalFuelCost:C}");
        Console.WriteLine($"Average Daily Fuel Cost: {averageCost:C}");
        Console.WriteLine($"Efficiency Rating: {efficiencyLabel}");
        Console.WriteLine($"Stayed Within Budget: {isWithinBudget}");

        Console.WriteLine("==============================================");
        Console.WriteLine("Report Generated Successfully.");
    }
}
