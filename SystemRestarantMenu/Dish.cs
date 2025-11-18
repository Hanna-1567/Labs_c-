using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemRestarantMenu
{
    public class Dish : Menu
    {
        public string Type { get; set; }
        public Dish(string name, decimal price, string category, string type) : base(name, price, category)
        {
            Type = type;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"{Name} ({Type}) - {Price} грн");
        }
    }
}
