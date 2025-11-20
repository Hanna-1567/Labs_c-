using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemRestarantMenu
{
    public class Program
    {
        static void Main(string[] args)
        {
            Restaurant restaurant = new Restaurant();

            // -------------------- Додаємо меню --------------------

            restaurant.MenuItems.Add(new Dish("Борщ", 120, "Перше", "Суп"));
            restaurant.MenuItems.Add(new Dish("Вареники з картоплею", 150, "Друге", "Основна страва"));
            restaurant.MenuItems.Add(new Dish("Салат Олів'є", 100, "Закуска", "Салат"));
            restaurant.MenuItems.Add(new Dish("Напалеон", 120, "Десерт", "Торт"));
            restaurant.MenuItems.Add(new Drink("Кава", 60, "Напій", 200, false));
            restaurant.MenuItems.Add(new Drink("Сік апельсиновий", 70, "Напій", 250, false));


            restaurant.DisplayMenu();

            // Пошук у меню
            restaurant.SearchInMenu("Борщ");
            restaurant.SearchInMenu("Напої");

            Console.WriteLine("---------------------");

            // -------------------- СТОЛИК №2 --------------------

            int tableNumber = 2;
            Table table = restaurant.GetTable(tableNumber);
            Console.WriteLine($"Замовлення для столика {tableNumber} :");

            Console.WriteLine("---------------------\n");

            Console.WriteLine("Замовлення 1 для столика 2:");

            Order order1 = restaurant.CreateOrder(tableNumber);
            order1.AddItem(restaurant.MenuItems[0]);
            order1.AddItem(restaurant.MenuItems[1]);
            order1.DisplayOrder();

            Console.WriteLine("---------------------\n");
            Console.WriteLine("Замовлення 2 для столика 2:");

            Order order2 = restaurant.CreateOrder(tableNumber);
            order2.AddItem(restaurant.MenuItems[3]);
            order2.AddItem(restaurant.MenuItems[5]);
            order2.AddItem(restaurant.MenuItems[4]);
            order2.RemoveItem(restaurant.MenuItems[4]);

            order2.DisplayOrder();

            Console.WriteLine("---------------------\n");

            Console.WriteLine("Об'єднане замовлення: \n");
           
            int mergedOrderId = 999;

            Order mergedOrder = table.MergeOrders(mergedOrderId);
            mergedOrder.DisplayOrder();

            Console.WriteLine("---------------------\n");

            // -------------------- СТОЛИК №5 --------------------

            int tableNumber2 = 5;
            Table table2 = restaurant.GetTable(tableNumber2);

            Menu item1 = new Dish("Спрінг-роли", 140, "Закуска", "Азійська");
            Menu item2 = new Drink("Саке", 80, "Напій", 300, true);


            Order table5_order1 = restaurant.CreateOrder(tableNumber2);

            table5_order1.AddItem(item1);
            table5_order1.AddItem(item2);

            table5_order1.DisplayOrder();

            Console.WriteLine("--------------------");

            foreach (var item in table5_order1.Items)
            {
                if (item is Dish dish)
                    Console.WriteLine($"{item.Name} - Тип страви: {dish.Category}");
                else if (item is Drink drink)
                    Console.WriteLine($"{item.Name} - Об’єм: {drink.Volume} мл, {(drink.IsAlcoholic ? "з алкоголем" : "без алкоголю")}");
            }


            Console.WriteLine("--------------------\n");

            // -------------------- Усі замовлення --------------------

            Console.WriteLine($"--- Усі замовлення за столиком №{tableNumber} ---");

            foreach (var order in table.Orders)
            {
                order.DisplayOrder();
            }

            Console.WriteLine($"--- Усі замовлення за столиком №{tableNumber2} ---");

            foreach (var order in table2.Orders)
            {
                order.DisplayOrder();
            }
            Console.WriteLine("--------------------\n");
            // Робота зі статусами
            order1.ChangeStatus(OrderStatus.InProgress);
            order1.ChangeStatus(OrderStatus.Ready);

            order2.ChangeStatus(OrderStatus.InProgress);
            order2.ChangeStatus(OrderStatus.Ready);

            table5_order1.ChangeStatus(OrderStatus.InProgress);

            Console.WriteLine("--------------------\n");

            restaurant.ShowAllOrders();

            Console.ReadLine();

        }
    }
    }