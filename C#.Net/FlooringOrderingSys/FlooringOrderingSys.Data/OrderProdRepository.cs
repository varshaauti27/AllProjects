using FlooringOrderingSys.Models;
using FlooringOrderingSys.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.Data
{
    public class OrderProdRepository : IOrderRepository
    {
        private string _dirPath;

        public OrderProdRepository(string dirpath)
        {
            this._dirPath = dirpath;
        }

        public int AddOrder(DateTime orderDate, Order order)
        {
            int orderNumber = -1;
            try
            {
                List<Order> allOrders = LoadOrders(orderDate);
               
                if (allOrders != null && allOrders.Count > 0)
                {
                    orderNumber = allOrders.Max(i => i.OrderNumber) + 1;
                }
                else
                {
                    orderNumber = 1;
                    allOrders = new List<Order>();
                }
                order.OrderNumber = orderNumber;
                allOrders.Add(order);

                string filename = _dirPath + "Orders_" + orderDate.ToString("MMddyyyy") + ".txt";
                SaveOrdersToFile(filename,allOrders);
            }
            catch
            {
                orderNumber= -1;
            }
            return orderNumber;
        }

        private void SaveOrdersToFile(string filename, List<Order> allOrders)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine("OrderNumber|CustomerName|State|TaxRate|ProductType|" +
                    "Area|CostPerSquareFoot|LaborCostPerSquareFoot|MaterialCost|LaborCost|Tax|Total");
                foreach (Order o in allOrders)
                {
                    writer.WriteLine(MapOrderToLine(o));
                }
            }
        }

        private string MapOrderToLine(Order o)
        {
            return o.OrderNumber + "|" + o.CustomerName + "|" + o.State + "|" + o.TaxRate + "|" +
                   o.ProductType + "|" + o.Area + "|" + o.CostPerSquareFoot + "|" + o.LaborCostPerSquareFoot + "|" +
                   o.MaterialCost + "|" + o.LaborCost + "|" + o.Tax + "|" + o.Total;
        }

        public int GetNextOrderId(DateTime orderDate)
        {
            List<Order> allOrders = LoadOrders(orderDate);

            return allOrders.Max(i => i.OrderNumber);
        }

        public List<Order> LoadOrders(DateTime dateTime)
        {
            List<Order> orders = new List<Order>();
            string filename = _dirPath + "Orders_" + dateTime.ToString("MMddyyyy") + ".txt";
            if (File.Exists(filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    reader.ReadLine();

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        orders.Add(MapLineToOrder(line));
                    }
                }
            }
            else
            {
                orders = null;
            }
            return orders;
        }

        private Order MapLineToOrder(string line)
        {
            string[] prop = line.Split('|');
            return new Order()
            {
                OrderNumber = int.Parse(prop[0]),
                CustomerName = prop[1],
                State = prop[2],
                TaxRate = decimal.Parse(prop[3]),
                ProductType = prop[4],
                Area = decimal.Parse(prop[5]),
                CostPerSquareFoot = decimal.Parse(prop[6]),
                LaborCostPerSquareFoot = decimal.Parse(prop[7]),
                MaterialCost = decimal.Parse(prop[8]),
                LaborCost = decimal.Parse(prop[9]),
                Tax = decimal.Parse(prop[10]),
                Total = decimal.Parse(prop[11])
            };
        }

        public Order GetOrder(DateTime orderDate, int orderNumber)
        {
            List<Order> all = LoadOrders(orderDate);

            if(all!=null)
                return all.Where(i=>i.OrderNumber==orderNumber).FirstOrDefault();
            return null;
        }

        public bool EditOrder(DateTime orderDate, Order newOrder)
        {
            try
            {
                List<Order> all = LoadOrders(orderDate);

                int index = all.FindIndex(i => i.OrderNumber == newOrder.OrderNumber);
                if (index != -1)
                {
                    all[index] = newOrder;
                }

                string filename = _dirPath + "Orders_" + orderDate.ToString("MMddyyyy") + ".txt";
                SaveOrdersToFile(filename, all);
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
                List<Order> all = LoadOrders(orderDate);

                int index = all.FindIndex(i => i.OrderNumber == orderNumber);
                all.RemoveAt(index);

                string filename = _dirPath + "Orders_" + orderDate.ToString("MMddyyyy") + ".txt";
                SaveOrdersToFile(filename, all);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool ValidateInput(DateTime orderDate, string custName, string state, string productType, decimal area)
        {
            throw new NotImplementedException();
        }
    }
}
