using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemRestarantMenu
{
    public class Table
    {
        public int TableNumber { get; private set; }
        public List<Order> Orders { get; } = new List<Order>();

        public Table( int tableNumer)
        {
            TableNumber = tableNumer; 
        }
        public Order MergeOrders(int newOrderId)
        {
            Order merged = new Order(newOrderId, TableNumber);
            foreach (var order in Orders)
            {
                foreach (var item in order.Items)
                    merged.AddItem(item);
            }
            merged.Status = OrderStatus.New;
            return merged;
        }

    }
}
