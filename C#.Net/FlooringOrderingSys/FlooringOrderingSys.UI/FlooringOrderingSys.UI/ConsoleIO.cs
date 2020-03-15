using FlooringOrderingSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.UI
{
    public static class ConsoleIO
    {
        public static string _seperator = "******************************************************************";
        public static string _orderSeperator = "=================================================================";
        static string _orderHeaderFormat = "{0,3} | {1,-20}";
        static string _productHeaderFormat = "{0,-3} {1,-15} {2,-18} {3,-15}";
        static string _productFormat = "{0,-3} {1,-15} {2,-18} {3,-15}";
        public static void DisplayOrders(List<Order> orders,DateTime dateTime)
        {
            foreach (Order order in orders)
            {
                Console.WriteLine();
                Console.WriteLine(_orderSeperator);

                Console.ForegroundColor = ConsoleColor.Yellow;
                if (order.OrderNumber != 0)
                {
                    Console.WriteLine(_orderHeaderFormat, order.OrderNumber, dateTime.ToString("MM/dd/yyyy"));
                }
                else
                {
                    Console.WriteLine(" Order Date : "+dateTime.ToString("MM/dd/yyyy"));
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" " + order.CustomerName);
                Console.WriteLine(" " + order.State);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  Product : " + order.ProductType);
                Console.WriteLine("Materials : " + order.MaterialCost);
                Console.WriteLine("    Labor : " + order.LaborCost);
                Console.WriteLine("      Tax : " + order.Tax);
                Console.WriteLine("    Total : " + order.Total);

                Console.WriteLine(_orderSeperator);
            }
        }

        public static void DisplayProducts(List<Product> products,bool displayIndexNo)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(_productHeaderFormat," ", "Product Type", "CostPerSquareFoot", "LaborCostPerSquareFoot");
            Console.ForegroundColor = ConsoleColor.White;
            if (displayIndexNo)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine(_productFormat, i + 1, products[i].ProductType, products[i].CostPerSquareFoot, products[i].LaborCostPerSquareFoot);
                }
            }
            else
            {
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine(_productFormat, "", products[i].ProductType, products[i].CostPerSquareFoot, products[i].LaborCostPerSquareFoot);
                }
            }
        }

        public static void DisplayTaxes(List<Tax> taxes)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0,-5} {1,-10} {2,-10}", "State", "StateName", "TaxRate");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var t in taxes)
            {
                Console.WriteLine("{0,-5} {1,-10} {2,-10}",t.StateAbbreviation,t.StateName,t.TaxRate);
            }
        }
    }
}
