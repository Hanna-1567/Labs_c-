using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemRestarantMenu
{
    public abstract class Menu
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Category { get; private set; }

        protected Menu(string name, decimal price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }

        // Вивід інформації про страву
        public abstract void DisplayInfo();
    }
}
