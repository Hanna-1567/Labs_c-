using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public interface ISwitchable
    {
        string Name { get; }

        void TurnOn();
        void TurnOff();
        bool IsOn { get; }
    }
}
