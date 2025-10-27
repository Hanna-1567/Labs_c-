using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem
{
     public class Van:Car
    {
        private double loadCapacity;  // вантажопідйомність (кг)
        private double currentLoad;   // поточне навантаження (кг)
        public Van(string brand, int year, double mileage, int doors, double loadCapacity)
            : base(brand, year, mileage, doors)
        {
            maxSpeed = 140.0;
            this.loadCapacity = loadCapacity;
            this.currentLoad = 0.0;
        }


        public override string GetInfo()
        {
            return $"Van: {brand} ({year}), Doors: {doors}, Load: {currentLoad:0}/{loadCapacity:0}kg, Fuel: {fuelLevel:0}L";
        }
        public void LoadCargo(double weight)
        {
            if (currentLoad + weight <= loadCapacity)
            {
                currentLoad += weight;
                Console.WriteLine($"{weight} kg loaded into the van.");
            }
            else
            {
                Console.WriteLine("Too heavy! Cannot load more cargo.");
            }
        }

        public void UnloadCargo()
        {
            currentLoad = 0.0;
            Console.WriteLine("Van unloaded.");
        }
    }
}
