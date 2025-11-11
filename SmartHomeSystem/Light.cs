using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public class Light : Device, IEnergyConsumer
    {
        public int PowerConsumption => 60;
        public string DeviceName => Name;

        public override void TurnOn()
        {
            if (!IsOn)
            {
                IsOn = true;
                Console.WriteLine($"{Name} засвітилася.");
            }
        }

        public override void TurnOff()
        {
            if (IsOn)
            {
                IsOn = false;
                Console.WriteLine($"{Name} вимкнена.");
            }
        }

        public double GetEnergyUsage(int hours)
        {
            if (!IsOn)
            {
                return 0;
            }
            return (PowerConsumption * hours) / 1000.0;
        }
    }
}