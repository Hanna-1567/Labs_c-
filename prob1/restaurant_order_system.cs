using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantOrderSystem
{
    // Перелік статусів замовлення (ТЕПЕР ЯК static class)
    public static class OrderStatus
    {
        public const string New = "New";
        public const string InProgress = "InProgress";
        public const string Ready = "Ready";
        public const string Paid = "Paid";
    }

    // Абстрактний клас для позицій меню (базова одиниця)
    public abstract class MenuItem
    {
        // Інкапсулюємо поля за допомогою властивостей
        public int Id { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        protected MenuItem(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        // Віртуальний метод для оформлення виводу
        public virtual string GetInfo() => $"{Name} - {Price} грн";
    }

    // Клас для страв (наступник MenuItem)
    public class Dish : MenuItem
    {
        public string Category { get; set; } // Наприклад: Перше, Друге, Десерт

        public Dish(int id, string name, decimal price, string category)
            : base(id, name, price)
        {
            Category = category;
        }

        public override string GetInfo() => $"{Name} ({Category}) - {Price} грн";
    }

    // Клас для напоїв (ще один наслідник)
    public class Drink : MenuItem
    {
        public int VolumeMl { get; set; }
        public bool IsAlcoholic { get; set; }

        public Drink(int id, string name, decimal price, int volumeMl, bool isAlcoholic)
            : base(id, name, price)
        {
            VolumeMl = volumeMl;
            IsAlcoholic = isAlcoholic;
        }

        public override string GetInfo() => $"{Name} ({VolumeMl} мл, {(IsAlcoholic ? "алкогольний" : "без алкоголю")}) - {Price} грн";
    }

    // Інтерфейс для об'єктів, які можна відображати в списку (демонстрація інтерфейсу)
    public interface IListable
    {
        string GetInfo();
    }

    // Замовлення — містить список позицій меню
    public class Order
    {
        private static int _nextId = 100; // Автоматичне генерування ID

        public int Id { get; }
        public int TableNumber { get; }

        // Тепер одна позиція замовлення може мати кількість
        private class OrderItem
        {
            public MenuItem Item { get; }
            public int Quantity { get; private set; }

            public OrderItem(MenuItem item)
            {
                Item = item;
                Quantity = 1;
            }

            public void Increase() => Quantity++;
        }

        private readonly List<OrderItem> _items = new List<OrderItem>(); // композиція
        public string Status { get; private set; }

        public Order(int tableNumber)
        {
            Id = _nextId++;
            TableNumber = tableNumber;
            Status = OrderStatus.New;
        }

        // Додаємо позицію або збільшуємо кількість (дозамовлення)
        public void AddItem(MenuItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var existing = _items.FirstOrDefault(i => i.Item.Id == item.Id);
            if (existing != null)
            {
                existing.Increase();
                Console.WriteLine($"Дозамовлено: {item.Name}. Кількість тепер: {existing.Quantity}");
            }
            else
            {
                _items.Add(new OrderItem(item));
                Console.WriteLine($"Додано позицію: {item.Name}");
            }
        }

        // Видаляємо позицію за id
        public bool RemoveItemById(int menuItemId)
        {
            var item = _items.FirstOrDefault(i => i.Item.Id == menuItemId);
            if (item == null) return false;
            _items.Remove(item);
            Console.WriteLine($"Видалено позицію: {item.Item.Name}");
            return true;
        }

        // Загальна сума
        public decimal GetTotal()
        {
            return _items.Sum(i => i.Item.Price * i.Quantity);
        }

        // Зміна статусу замовлення
        public void SetStatus(string newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"> Змінено статус: {Status}");
        }

        // Отримати копію списку позицій
        public IReadOnlyList<(MenuItem Item, int Quantity)> GetItems()
        {
            return _items.Select(i => (i.Item, i.Quantity)).ToList().AsReadOnly();
        }

        public override string ToString()
        {
            return $"ID: {Id} | Стіл: {TableNumber} | Статус: {Status} | Сума: {GetTotal()} грн";
        }
    }

    // Ресторан — агрегує меню та активні замовлення
    public class Restaurant
    {
        private readonly List<MenuItem> _menu = new List<MenuItem>();
        private readonly List<Order> _orders = new List<Order>();

        public void AddToMenu(MenuItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _menu.Add(item);
        }

        public void PrintMenu()
        {
            Console.WriteLine("--- МЕНЮ РЕСТОРАНУ ---");
            foreach (var item in _menu)
            {
                Console.WriteLine($"{item.Id}. {item.GetInfo()}");
            }
            Console.WriteLine("-----------------------");
        }

        public List<MenuItem> SearchMenuByName(string namePart)
        {
            return _menu.Where(m => m.Name.IndexOf(namePart, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        public List<MenuItem> SearchMenuByCategory(string category)
        {
            return _menu.Where(m => (m is Dish d) && d.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public Order CreateOrder(int tableNumber)
        {
            var order = new Order(tableNumber);
            _orders.Add(order);
            Console.WriteLine($"Створено нове замовлення для столика №{tableNumber} (ID: {order.Id})");
            return order;
        }

        public Order FindOrderById(int id) => _orders.FirstOrDefault(o => o.Id == id);

        public void PrintAllOrders()
        {
            Console.WriteLine("--- УСІ ЗАМОВЛЕННЯ ---");
            foreach (var order in _orders)
            {
                Console.WriteLine(order.ToString());
            }
            Console.WriteLine();
        }

        public MenuItem GetMenuItemById(int id) => _menu.FirstOrDefault(m => m.Id == id);

        public bool RemoveOrder(int id)
        {
            var order = FindOrderById(id);
            if (order == null) return false;
            _orders.Remove(order);
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var restaurant = new Restaurant();

            restaurant.AddToMenu(new Dish(1, "Борщ", 120m, "Перше"));
            restaurant.AddToMenu(new Dish(2, "Відбивна з картоплею", 200m, "Друге"));
            restaurant.AddToMenu(new Drink(3, "Кава", 60m, 200, false));
            restaurant.AddToMenu(new Drink(4, "Сік апельсиновий", 70m, 250, false));
            restaurant.AddToMenu(new Drink(5, "Вино червоне", 180m, 150, true));

            restaurant.PrintMenu();

            var order1 = restaurant.CreateOrder(tableNumber: 5);

            MenuItem firstItem = restaurant.GetMenuItemById(1);
            MenuItem coffee = restaurant.GetMenuItemById(3);

            order1.AddItem(firstItem);
            order1.AddItem(coffee);

            Console.WriteLine($"Поточна сума: {order1.GetTotal()} грн\n");

            foreach (var it in order1.GetItems())
            {
                if (it.Item is Drink d)
                {
                    Console.WriteLine($"(Downcast) Напій у замовленні: {d.Name}, об'єм: {d.VolumeMl} мл");
                }
            }

            Console.WriteLine($"Статус замовлення: {order1.Status}");
            order1.SetStatus(OrderStatus.InProgress);
            order1.SetStatus(OrderStatus.Ready);
            order1.SetStatus(OrderStatus.Paid);

            restaurant.PrintAllOrders();

            var found = restaurant.SearchMenuByName("Кава");
            Console.WriteLine("Результат пошуку за назвою 'Кава':");
            foreach (var f in found) Console.WriteLine(f.GetInfo());

            // Показати приклад дозамовлення
            order1.AddItem(coffee); // дозамовлення кави
            order1.AddItem(coffee); // ще раз
            Console.WriteLine($"Поточна сума після дозамовлень: {order1.GetTotal()} грн
");

            // Приклад поділу чека (якщо за столиком кілька чеків)
            // Припустимо, що перший гість оплатить Борщ (id 1) і одну Каву (id 3)
            var splitSums = new List<decimal>
            {
                order1.GetItems().Where(x => x.Item.Id == 1 || x.Item.Id == 3).Sum(x => x.Item.Price * x.Quantity),
                order1.GetItems().Where(x => x.Item.Id != 1 && x.Item.Id != 3).Sum(x => x.Item.Price * x.Quantity)
            };

            Console.WriteLine($"Чек №1: {splitSums[0]} грн");
            Console.WriteLine($"Чек №2: {splitSums[1]} грн
");

            // Створимо ще одне замовлення і покажемо видалення позиції
            var order2 = restaurant.CreateOrder(2);
            order2.AddItem(restaurant.GetMenuItemById(2)); // відбивна
            order2.AddItem(restaurant.GetMenuItemById(4)); // сік
            Console.WriteLine($"Сума перед видаленням: {order2.GetTotal()} грн");
            order2.RemoveItemById(4);
            Console.WriteLine($"Сума після видалення: {order2.GetTotal()} грн
");

            // Пошук замовлення за ID
            var byId = restaurant.FindOrderById(order1.Id);
            Console.WriteLine(byId != null ? $"Знайдено замовлення: {byId}" : "Замовлення не знайдено");

            Console.WriteLine("
Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
