using FlooringOrderingSys.BLL;
using FlooringOrderingSys.Models;
using FlooringOrderingSys.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlooringOrderingSys.UI.Workflows
{
    class AddWorkflow
    {
        public void ExecuteAddOrder()
        {
            Console.Clear();
            Console.WriteLine("Add Order");
            Console.WriteLine(ConsoleIO._seperator);

            DateTime orderDate;
            string custName = "";
            string state = "", productType = "";
            decimal area;

            try
            {
                OrderManager manager = OrderManagerFactory.Create();              

                Console.Write("Enter Order Date(future)(MM/dd/yyyy) : ");
                while (true)
                {
                    if (DateTime.TryParse(Console.ReadLine(), out orderDate) && DateTime.Compare(orderDate, DateTime.Now) > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Please Enter Valid Date : ");
                    }
                }

                Console.Write("\nEnter Customer Name : ");
                while (true)
                {
                    custName = Console.ReadLine();
                    if (!String.IsNullOrEmpty(custName) && Regex.IsMatch(custName, "([A-Z]*,|.|[a-z]*,|.|[0-9])*$"))
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Enter Valid Customer Name : ");
                    }
                }

                TaxManager taxManager = TaxManagerFactory.Create();
                LoadTaxesResponse taxesResponse = taxManager.LoadTaxes();

                Console.WriteLine("\nSelect State from following: ");
                if (!taxesResponse.Success)
                {
                    Console.WriteLine("\nNo Tax information available...");
                    Console.WriteLine(taxesResponse.Message);
                    return;
                }
                ConsoleIO.DisplayTaxes(taxesResponse.Taxes);

                Console.Write("Enter State : ");
                while (true)
                {
                    state = Console.ReadLine().ToUpper();
                    if (String.IsNullOrEmpty(state))
                    {
                        Console.Write("Please Enter Valid State : ");
                        continue;
                    }

                    if (!(taxesResponse.Taxes.Exists(i => i.StateAbbreviation.Equals(state))))
                    {
                        Console.WriteLine("\nNo Tax information found !!!!");
                        return;
                    }
                    break;
                }

                Console.WriteLine("\nSelect product type from following : ");

                ProductManager productManager = ProductManagerFactory.Create();
                LoadProductsResponse productResponse = productManager.LoadProducts();

                if (productResponse.Success)
                {
                    ConsoleIO.DisplayProducts(productResponse.Products,true);
                }
                else
                {
                    Console.WriteLine(productResponse.Message);
                    //Console.WriteLine("\nPress any key to continue....");
                    return;
                }

                Console.Write("Enter Selection : ");
                while (true)
                {
                    int index;
                    if (int.TryParse(Console.ReadLine(), out index) && (index > 0) && (index <= productResponse.Products.Count))
                    {
                        productType = productResponse.Products[index - 1].ProductType;
                        break;
                    }
                    else
                    {
                        Console.Write("Please enter valid option : ");
                    }
                }

                Console.Write("\nEnter Area(Minimun 100 sq.ft) : ");
                while (true)
                {
                    if (!(decimal.TryParse(Console.ReadLine(), out area) && (area >= 100)))
                    {
                        Console.Write("Please enter valid area : ");
                        continue;
                    }
                    break;
                }

                Order _newOrder = GererateOrder.Create(custName, state, productType, area, taxesResponse, productResponse);

                ConsoleIO.DisplayOrders(new List<Order>() { _newOrder }, orderDate);

                Console.Write("\nDo you want to Add above Order ??(Y/N) : ");
                string input = Console.ReadLine();

                if (input.ToUpper().Equals("Y"))
                {
                    AddOrderResponse addOrderResponse = manager.AddOrder(orderDate, _newOrder);
                    if (addOrderResponse.Success)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n" + addOrderResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Adding Order : " + ex);
            }
        }

        public void ExecuteAddProduct()
        {
            Console.Clear();
            Console.WriteLine("Add Product");
            Console.WriteLine(ConsoleIO._seperator);

            try
            {
                string productType = "";
                decimal costPerSquareFoot, laborCostPerSquareFoot;

                ProductManager productManager = ProductManagerFactory.Create();

                Console.Write("Enter Product Type : ");
                while (true)
                {
                    productType = Console.ReadLine();
                    if (!(String.IsNullOrEmpty(productType)) && Regex.IsMatch(productType, "([A-Z]*,|.|[a-z]*,|.|[0-9])*$"))
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Please Enter Product Type : ");
                    }
                }

                Console.Write("\nEnter CostPerSquareFoot : ");
                while (true)
                {
                    if (decimal.TryParse(Console.ReadLine(), out costPerSquareFoot))
                    {
                        costPerSquareFoot = decimal.Round(costPerSquareFoot, 2);
                        break;
                    }
                    else
                    {
                        Console.Write("Please Enter CostPerSquareFoot : ");
                    }
                }

                Console.Write("\nEnter LaborCostPerSquareFoot : ");
                while (true)
                {
                    if (decimal.TryParse(Console.ReadLine(), out laborCostPerSquareFoot))
                    {
                        laborCostPerSquareFoot = decimal.Round(laborCostPerSquareFoot, 2);
                        break;
                    }
                    else
                    {
                        Console.Write("Please Enter LaborCostPerSquareFoot : ");
                    }
                }
                Product _newProduct = new Product { ProductType = productType, CostPerSquareFoot = costPerSquareFoot, LaborCostPerSquareFoot = laborCostPerSquareFoot };

                ConsoleIO.DisplayProducts(new List<Product> { _newProduct },false);

                Console.Write("\nDo you want to Add above Product ??(Y/N) : ");
                string input = Console.ReadLine();

                if (input.ToUpper().Equals("Y"))
                {
                    Response response = productManager.AddProduct(_newProduct);
                    if (response.Success)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n" + response.Message);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in Adding Product : " + ex.Message);
            }
        }
        public void ExecuteAddTax()
        {
            Console.Clear();
            Console.WriteLine("Add Taxes");
            Console.WriteLine(ConsoleIO._seperator);

            string stateAbbreviation, stateName;
            decimal taxRate;
            try
            {
                TaxManager taxManager = TaxManagerFactory.Create();

                Console.Write("Enter StateAbbreviation : ");
                while (true)
                {
                    stateAbbreviation = Console.ReadLine().ToUpper();
                    if (!(String.IsNullOrEmpty(stateAbbreviation)) && Regex.IsMatch(stateAbbreviation, "([A-Z]*,|.|[a-z]*,|.|[0-9])*$"))
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Please Enter Valid StateAbbreviation : ");
                    }
                }
                Console.Write("\nEnter StateName : ");
                while (true)
                {
                    stateName = Console.ReadLine();
                    if (!(String.IsNullOrEmpty(stateName)) && Regex.IsMatch(stateName, "([A-Z]*,|.|[a-z]*,|.|[0-9])*$"))
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Please Enter Valid StateName : ");
                    }
                }
                Console.Write("\nEnter TaxRate : ");
                while (true)
                {
                    string input = Console.ReadLine();
                    if (decimal.TryParse(input, out taxRate) && taxRate >= 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Please Enter Valid TaxRate : ");
                    }
                }

                Tax _tax = new Tax
                {
                    StateAbbreviation = stateAbbreviation,
                    StateName = stateName,
                    TaxRate = Decimal.Round(taxRate, 2)
                };

                ConsoleIO.DisplayTaxes(new List<Tax> { _tax });

                Console.Write("\nDo you want to Add above Tax information ??(Y/N) : ");
                string input1 = Console.ReadLine();

                if (input1.ToUpper().Equals("Y"))
                {
                    Response addTaxResponse = taxManager.AddTax(_tax);
                    if (addTaxResponse.Success)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n" + addTaxResponse.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Adding Taxes : " + ex.Message);
            }

        }
    }
}
