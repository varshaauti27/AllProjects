using FlooringOrderingSys.BLL;
using FlooringOrderingSys.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.UI.Workflows
{
    public class RemoveWorkflow
    {
        public void ExecuteRemoveOrder()
        {
            Console.Clear();
            Console.WriteLine("Remove Order");
            Console.WriteLine(ConsoleIO._seperator);

            DateTime orderDate;
            int orderNumber;

            try
            {
                OrderManager orderManager = OrderManagerFactory.Create();

                Console.Write("Enter Order Date(MM/dd/yyyy) : ");
                while (true)
                {
                    if (DateTime.TryParse(Console.ReadLine(), out orderDate))
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Please Enter Valid Date : ");
                    }
                }

                Console.Write("\nEnter Order Number : ");
                while (true)
                {
                    if (!(int.TryParse(Console.ReadLine(), out orderNumber)) && orderNumber <= 0)
                    {
                        Console.Write("Please Enter valid Order Number : ");
                        continue;
                    }
                    break;
                }

                OrderResponse orderResponse = orderManager.GetOrder(orderDate, orderNumber);
                if (!orderResponse.Success)
                {
                    Console.WriteLine(orderResponse.Message);
                    return;
                }

                ConsoleIO.DisplayOrders(new List<Models.Order>() { orderResponse.Order }, orderDate);

                Console.Write("\nDo you want to remove order??(Y/N) : ");
                string input = Console.ReadLine();

                if (input.ToUpper().Equals("Y"))
                {
                    Response removeOrderResponse = orderManager.RemoveOrder(orderDate, orderNumber);
                    if (removeOrderResponse.Success)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("\n"+removeOrderResponse.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in RemoveOrderWorkflow : "+e.Message);
            }
        }

        public void ExecuteRemoveProduct()
        {
            Console.Clear();
            Console.WriteLine("Remove Product");
            Console.WriteLine(ConsoleIO._seperator);

            Console.Write("Enter Product Type : ");
            string productType = "";
            while (true)
            {
                productType = Console.ReadLine();
                if (String.IsNullOrEmpty(productType))
                {
                    Console.Write("Please enter Product Type : ");
                    continue;
                }
                break;
            }

            ProductManager productManager = ProductManagerFactory.Create();
            ProductResponse productResponse = productManager.GetProduct(productType);
            if (!productResponse.Success)
            {
                Console.WriteLine(productResponse.Message);
                return;
            }

            ConsoleIO.DisplayProducts(new List<Models.Product> { productResponse.Product }, false);

            Console.Write("\nDo you want to remove Product??(Y/N) : ");
            string input = Console.ReadLine();

            if (input.ToUpper().Equals("Y"))
            {
                Response removeProductResponse = productManager.RemoveProduct(productType);
                if (removeProductResponse.Success)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("\n" + removeProductResponse.Message);
            }
        }

        public void ExecuteRemoveTax()
        {
            Console.Clear();
            Console.WriteLine("Remove Tax");
            Console.WriteLine(ConsoleIO._seperator);

            Console.Write("Enter StateAbbreviation : ");
            string stateAbbreviation = "";
            while (true)
            {
                stateAbbreviation = Console.ReadLine();
                if (String.IsNullOrEmpty(stateAbbreviation))
                {
                    Console.Write("Please Enter StateAbbreviation : ");
                    continue;
                }
                break;
            }

            TaxManager taxManager = TaxManagerFactory.Create();
            TaxResponse taxResponse = taxManager.GetTax(stateAbbreviation);
            if (!taxResponse.Success)
            {
                Console.WriteLine(taxResponse.Message);
                return;
            }

            ConsoleIO.DisplayTaxes(new List<Models.Tax> { taxResponse.Tax });

            Console.Write("\nDo you want to remove Tax??(Y/N) : ");
            string input = Console.ReadLine();

            if (input.ToUpper().Equals("Y"))
            {
                Response removeTaxResponse = taxManager.RemoveTax(stateAbbreviation);
                if (removeTaxResponse.Success)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("\n" + removeTaxResponse.Message);
            }
        }
    }
}
