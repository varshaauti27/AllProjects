using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.Models.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> LoadOrders(DateTime orderDate);
        Order GetOrder(DateTime orderDate,int orderNumber);
        int AddOrder(DateTime orderDate, Order order);
        bool EditOrder(DateTime orderDate, Order newOrder);
        bool RemoveOrder(DateTime orderDate, int orderNumber);
    }
}