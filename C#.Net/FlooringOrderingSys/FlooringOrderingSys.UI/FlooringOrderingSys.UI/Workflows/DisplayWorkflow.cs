using FlooringOrderingSys.BLL;
using FlooringOrderingSys.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.UI.Workflows
{
    class DisplayWorkflow
    {
        public void ExecuteDisplayOrder()
        {
            Console.Clear();
            
            Console.WriteLine("Display Orders");
            Console.WriteLine(ConsoleIO._seperator);
            Console.Write("Enter Order Date(MM/dd/yyyy) : ");

            OrderManager manager = OrderManagerFactory.Create();
            try
            {
                DateTime orderDate;
                while (true)
                {
                    if (DateTime.TryParse(Console.ReadLine(), out orderDate))
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Enter valid date : ");
                    }
                }

                LoadOrdersResponse response = manager.LoadOrders(orderDate);

                if (response.Success)
                {
                    ConsoleIO.DisplayOrders(response.Orders,response.OrderDate);
                }
                else
                {
                    Console.Write("Error occured : ");
                    Console.WriteLine(response.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in DisplayOrderWorkflow : " + e.Message);
            }
        }

        public void ExecuteDisplayProducts()
        {
            Console.Clear();
            Console.WriteLine("Display Products");
            Console.WriteLine(ConsoleIO._seperator);

            ProductManager productManager = ProductManagerFactory.Create();
            LoadProductsResponse productResponse = productManager.LoadProducts();

            if (productResponse.Success)
            {
                ConsoleIO.DisplayProducts(productResponse.Products,true);
            }
            else
            {
                Console.Write("Error Occured : ");
                Console.WriteLine(productResponse.Message);
            }

        }

        public void ExecuteDisplayTaxes()
        {
            Console.Clear();
            Console.WriteLine("Display Taxes");
            Console.WriteLine(ConsoleIO._seperator);

            TaxManager taxManager = TaxManagerFactory.Create();
            LoadTaxesResponse taxesResponse = taxManager.LoadTaxes();

            if (taxesResponse.Success)
            {
                ConsoleIO.DisplayTaxes(taxesResponse.Taxes);
            }
            else
            {
                Console.Write("Error Occured : ");
                Console.WriteLine(taxesResponse.Message);
            }
        }
    }
}
