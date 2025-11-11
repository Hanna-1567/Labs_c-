using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public abstract class Device : ISwitchable
    {
        public required string Name { get; set; }
        public bool IsOn { get; protected set; }

        public abstract void TurnOn();
        public abstract void TurnOff();

        public void PrintStatus()
        {
            string status = IsOn ? "увімкнено" : "вимкнено";
            Console.WriteLine($"{Name}: {status}");
        }
    }
}
