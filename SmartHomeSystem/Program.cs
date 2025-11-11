namespace SmartHomeSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var controller = new SmartHomeController();

            var light = new Light { Name = "Лампа у вітальні" };
            var ac = new AirConditioner { Name = "Кондиціонер у спальні" };
            var coffeeMachine = new CoffeeMachine { Name = "Кавомашина на кухні" };
            var sensor = new MotionSensor { Name = "Датчик руху у коридорі" };

            controller.AddDevice(light);
            controller.AddDevice(ac);
            controller.AddDevice(coffeeMachine);
            controller.AddDevice(sensor);

            controller.AddEnergyDevice(light);
            controller.AddEnergyDevice(ac);
            controller.AddEnergyDevice(coffeeMachine);

            controller.TurnAllOn();

            Console.WriteLine(); 
            light.PrintStatus();
            ac.PrintStatus();
            coffeeMachine.PrintStatus();
            sensor.PrintStatus();

            controller.ShowEnergyReport(5);

            Console.WriteLine(); 
            controller.TurnAllOff();
        }
    }
}
