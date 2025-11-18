using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemRestarantMenu
{
    public class Restaurant
    {
        public List<Menu> MenuItems { get; } = new List<Menu>();
        public List<Table> Tables { get; } = new List<Table>();

        private int nextOrderId = 1;

        public Restaurant()
        {
            MenuItems = new List<Menu>();
            Tables = new List<Table>();
        }

        // Метод отримання столика (замість FirstOrDefault використовуємо цикл)
        public Table GetTable(int tableNumber)
        {

            foreach (Table t in Tables)
            {
                if (t.TableNumber == tableNumber)
                {
                    return t;
                }
            }

            Table newTable = new Table(tableNumber);
            Tables.Add(newTable);
            return newTable;
        }

        public Order CreateOrder(int tableNumber)
        {
            Order newOrder = new Order(nextOrderId, tableNumber);
            nextOrderId++; // Збільшуємо ID для наступного разу

            Table t = GetTable(tableNumber);
            t.Orders.Add(newOrder);

            return newOrder;
        }
        public void DisplayMenu()
        {
            Console.WriteLine("--- МЕНЮ РЕСТОРАНУ ---");
            foreach (var item in MenuItems)
                item.DisplayInfo();
            Console.WriteLine("---------------------\n");
        }
        // Пошук страви у меню 
        public void SearchInMenu(string text)
        {
            Console.WriteLine("Пошук у меню за словом: " + text);
            bool found = false;
            foreach (Menu item in MenuItems)
            {
                // Перевіряємо, чи міститься текст у назві або категорії
                if (item.Name.Contains(text) || item.Category.Contains(text))
                {
                    item.DisplayInfo();
                    found = true;
                }
            }
            if (found == false)
            {
                Console.WriteLine("Нічого не знайдено.");
            }
            Console.WriteLine();
        }

        public void ShowAllOrders()
        {
            Console.WriteLine("\n--- Усі активні замовлення ---");
            foreach (Table t in Tables)
            {
                foreach (Order o in t.Orders)
                {
                    Console.WriteLine("ID: " + o.Id + " | Стіл: " + o.TableNumber + " | Статус: " + o.Status + " | Сума: " + o.GetTotalPrice());
                }
            }
            Console.WriteLine("------------------------------");
        }

    }
}
