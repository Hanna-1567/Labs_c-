using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemRestarantMenu
{
    public class Order 
    {
        public int Id { get; private set; }
        public int TableNumber { get; private set; }
        public OrderStatus Status { get; set; } = OrderStatus.New;
        
        // Список страв у замовленні
        public List<Menu> Items { get; } = new List<Menu>();

        public Order(int id, int tableNumer)
        {
            Id = id;
            TableNumber = tableNumer;
        }
        //Додає дозамовлення
        public void AddItem(Menu item)
        { 
            Items.Add(item);
            Console.WriteLine("Додано до замовлення: " + item.Name);
        }
        //Видаляє з замовлення
        public void RemoveItem(Menu item)
        {
            Items.Remove(item);
            Console.WriteLine("Видалено з замовлення: " + item.Name);
        }
        //Підрахунок загальної вартості замовлення
        public decimal GetTotalPrice() 
        {
            decimal total = 0;

            foreach (Menu item in Items)
            {
                total += item.Price;
            }
            return total;
        }
        //Статус замовлення
        public void ChangeStatus(OrderStatus status) {
            Status = status;
            Console.WriteLine("Статус замовлення №" + Id + " змінено на " + Status);
        }

        // Вивід інформації про замовлення
        public void DisplayOrder()
        {
            Console.WriteLine($"Замовлення №{Id} для столика №{TableNumber}:");
            foreach (var item in Items)
                item.DisplayInfo();
            Console.WriteLine($"Загальна вартість: {GetTotalPrice()} грн\nСтатус: {Status}\n");
        }
    }
}
