using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemRestarantMenu
{
    public interface IOrder
    {
        int Id { get; }
        int TableNumber { get; }
        OrderStatus Status { get; set; }

        void AddItem(Menu item);
        void RemoveItem(Menu item);
        decimal GetTotalPrice();
        void ChangeStatus(OrderStatus newStatus);
        void DisplayOrder();
    }

}
