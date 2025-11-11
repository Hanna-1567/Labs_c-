using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public class SmartHomeController
    {
        private List<ISwitchable> _allDevices = new List<ISwitchable>();
        private List<IEnergyConsumer> _energyDevices = new List<IEnergyConsumer>();

        public void AddDevice(ISwitchable device)
        {
            _allDevices.Add(device);
        }

        public void AddEnergyDevice(IEnergyConsumer device)
        {
            _energyDevices.Add(device);
        }

        public void TurnAllOn()
        {
            foreach (var device in _allDevices)
            {
                device.TurnOn();
            }
        }

        public void TurnAllOff()
        {
            foreach (var device in _allDevices)
            {
                device.TurnOff();
            }
        }

        public void ShowEnergyReport(int hours)
        {
            Console.WriteLine($"\nЗвіт про споживання енергії за {hours} год:");

            double totalEnergy = 0;

            foreach (var consumer in _energyDevices)
            {
                double energyUsed = consumer.GetEnergyUsage(hours);
                totalEnergy += energyUsed;

                Console.WriteLine($"- {consumer.DeviceName}: {energyUsed:F2} кВт·год (потужність: {consumer.PowerConsumption} Вт)");
            }

            Console.WriteLine($"Загальне споживання: {totalEnergy:F2} кВт·год");
            double cost = totalEnergy * 4.0;
            Console.WriteLine($"Вартість (~4 грн/кВт·год): {cost:F2} грн");
        }
    }
}
