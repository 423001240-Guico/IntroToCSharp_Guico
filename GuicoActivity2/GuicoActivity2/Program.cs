using System;

namespace Guico_ScenarioD
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CarbonFilter carbon = new CarbonFilter("CF-101", 5);
                ChemicalFilter chemical = new ChemicalFilter("CH-202", 50);

                carbon.ProcessWater(120);
                chemical.ProcessWater(150);

                Console.WriteLine("\nFiltration Efficiency Results:");

                Console.WriteLine($"Carbon Efficiency: {carbon.CalculateEfficiency():F2}");
                Console.WriteLine($"Chemical Efficiency: {chemical.CalculateEfficiency():F2}");
            }

            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Efficiency Error: " + ex.Message);
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine("Input Error: " + ex.Message);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }

            finally
            {
                Console.WriteLine("\nSystem Shutdown");
            }
        }
    }
}