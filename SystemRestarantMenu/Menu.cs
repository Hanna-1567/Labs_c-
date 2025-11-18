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
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Назва страви не може бути порожньою");

            if (price < 0)
                throw new ArgumentException("Ціна не може бути від’ємною");

            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Категорія не може бути порожньою");


            Name = name;
            Price = price;
            Category = category;
        }
        public abstract void DisplayInfo();
    }
}
