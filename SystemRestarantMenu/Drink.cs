using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemRestarantMenu
{
    public class Drink : Menu
    {
        public int Volume { get; private set; }
        public bool IsAlcoholic { get; private  set; }
        public Drink(string name, decimal price, string category, int volume, bool isAlcoholic) : base(name, price, category)
        {
            Volume = volume;
            IsAlcoholic = isAlcoholic;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"{Name} ({Volume} мл, {(IsAlcoholic ? "з алкоголем" : "без алкоголю")}) - {Price} грн");
        }
    }
}
