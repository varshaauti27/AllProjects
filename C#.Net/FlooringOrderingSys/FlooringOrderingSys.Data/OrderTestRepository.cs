using FlooringOrderingSys.Models;
using FlooringOrderingSys.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.Data
{
    public class OrderTestRepository : IOrderRepository
    {
        List<Order> orders = new List<Order>()
        {
            new Order
            {
                OrderNumber = 1, CustomerName = "Wise", State = "OH", TaxRate = 6.25M, ProductType = "Wood",
                Area = 100.00M, CostPerSquareFoot = 5.15M, LaborCostPerSquareFoot = 4.75M, MaterialCost = 515.00M,
                LaborCost = 475.00M, Tax = 61.88M, Total = 1051.88M
            },
            new Order
            {
                OrderNumber = 2, CustomerName = "Bryan", State = "IN", TaxRate = 6.00M, ProductType = "Tile",
                Area = 100.00M , CostPerSquareFoot = 3.50M, LaborCostPerSquareFoot = 4.15M, MaterialCost = 350.00M,
                LaborCost = 415.00M, Tax = 45.90M, Total = 810.90M
            },
            new Order
            {
                OrderNumber = 3, CustomerName ="Kree,Inc", State = "MI", TaxRate = 5.75M, ProductType = "Wood",
                Area = 250.00M , CostPerSquareFoot = 5.15M, LaborCostPerSquareFoot = 4.75M, MaterialCost = 1287.50M,
                LaborCost = 1187.50M, Tax = 142.31M, Total = 2617.31M
            },
            new Order
            {
                OrderNumber = 4, CustomerName ="Tom", State = "PA", TaxRate = 6.75M, ProductType = "Tile",
                Area = 210.00M , CostPerSquareFoot = 3.50M, LaborCostPerSquareFoot = 4.15M, MaterialCost = 735.00M,
                LaborCost = 871.50M, Tax = 108.44M, Total = 1714.94M
            }
        };

        public List<Order> LoadOrders(DateTime orderDate)
        {
            if (DateTime.Compare(orderDate, DateTime.Parse("1/1/2021")) == 0)
                return orders;
            else
                return null;
        }

        public int AddOrder(DateTime orderDate, Order order)
        {
            int orderNumber = 0;
            try
            {
                if (!(DateTime.Compare(orderDate, DateTime.Parse("1/1/2021")) == 0))
                    return -1;

                if (orders != null && orders.Count > 0)
                    orderNumber = orders.Max(i => i.OrderNumber);

                orderNumber += 1;
                order.OrderNumber = orderNumber;
                orders.Add(order);
            }
            catch
            {
                orderNumber = -1;
            }
            return orderNumber;
        }

        public Order GetOrder(DateTime orderDate, int orderNumber)
        {
            if (DateTime.Compare(orderDate, DateTime.Parse("1/1/2021")) == 0)
                return orders.Where(i => i.OrderNumber == orderNumber).FirstOrDefault();
            else
                return null;
        }

        public bool EditOrder(DateTime orderDate, Order newOrder)
        {
            try
            {
                if (!(DateTime.Compare(orderDate, DateTime.Parse("1/1/2021")) == 0))
                    return false;

                int index = orders.FindIndex(i => i.OrderNumber == newOrder.OrderNumber);

                if (index != -1)
                    orders[index] = newOrder;
                else
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool RemoveOrder(DateTime orderDate, int orderNumber)
        {
            try
            {
                if (!(DateTime.Compare(orderDate, DateTime.Parse("1/1/2021")) == 0))
                    return false;

                int index = orders.FindIndex(i => i.OrderNumber == orderNumber);
                if (index != -1)
                {
                    orders.RemoveAt(index);
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool ValidateInput(DateTime orderDate, string custName, string state, string productType, decimal area)
        {
            try
            {
                if (DateTime.Compare(DateTime.Today, orderDate) <= 0)
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}