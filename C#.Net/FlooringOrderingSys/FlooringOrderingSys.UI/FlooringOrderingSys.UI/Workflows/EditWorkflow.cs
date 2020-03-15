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
    class EditWorkflow
    {
        public void ExecuteEditOrder()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Edit Order");
                Console.WriteLine(ConsoleIO._seperator);

                DateTime orderDate;
                int orderNumber;

                OrderManager orderManager = OrderManagerFactory.Create();

                Console.Write("Enter Order Number : ");
                while (true)
                {
                    if (!(int.TryParse(Console.ReadLine(), out orderNumber)) && orderNumber <= 0)
                    {
                        Console.Write("Please enter valid order number : ");
                        continue;
                    }
                    break;
                }

                Console.Write("\nEnter Order Date(MM/dd/yyyy) : ");
                while (true)
                {
                    if (DateTime.TryParse(Console.ReadLine(), out orderDate))
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Please Enter valid Date : ");
                    }
                }

                OrderResponse orderResponse = orderManager.GetOrder(orderDate, orderNumber);
                if (!orderResponse.Success)
                {
                    Console.WriteLine(orderResponse.Message);
                    return;
                }

                Order currentOrder = orderResponse.Order;
                currentOrder.OrderNumber = orderNumber;
                Order oldOrder = currentOrder;
                Console.WriteLine();

                bool isEdit = false;
                string custName, state,productType;
                decimal area;

                Console.Write($"Enter customer name({currentOrder.CustomerName}) : ");
                while (true)
                {
                    custName = Console.ReadLine();

                    if (String.IsNullOrEmpty(custName))
                        break;
                    if (Regex.IsMatch(custName, "([A-Z]*,|.|[a-z]*,|.|[0-9])*$"))
                    {
                        currentOrder.CustomerName = custName;
                        isEdit = true;
                        break;
                    }
                    else
                    {
                        Console.Write("Enter Valid Customer Name : ");
                    }
                }

                Console.WriteLine("\nSelect State from following : ");
                TaxManager taxManager = TaxManagerFactory.Create();
                LoadTaxesResponse taxesResponse = taxManager.LoadTaxes();

                if (!taxesResponse.Success)
                {
                    Console.WriteLine("\n"+taxesResponse.Message);
                }

                ConsoleIO.DisplayTaxes(taxesResponse.Taxes);

                Console.Write($"Enter State({currentOrder.State}): ");

                while (true)
                {
                    state = Console.ReadLine().ToUpper();
                    if (String.IsNullOrEmpty(state))
                    {
                        state = currentOrder.State;
                        break;
                    }
                    if (!(taxesResponse.Taxes.Exists(i => i.StateAbbreviation.Equals(state))))
                    {
                        Console.WriteLine(taxesResponse.Message);
                        Console.Write("Please enter valid state : ");
                        continue;
                    }
                    break;
                }

                if (!currentOrder.State.Equals(state))
                {
                    isEdit = true;
                    currentOrder.State = state;
                    currentOrder.TaxRate = taxesResponse.Taxes.Where(i => i.StateAbbreviation.Equals(state)).Select(i => i.TaxRate).FirstOrDefault();
                    currentOrder.Tax = decimal.Round((currentOrder.MaterialCost + currentOrder.LaborCost) * (currentOrder.TaxRate / 100), 2);
                    currentOrder.Total = decimal.Round((currentOrder.MaterialCost + currentOrder.LaborCost + currentOrder.Tax), 2);
                }

                Console.WriteLine("\nSelect Product Type from following : ");

                ProductManager productManager = ProductManagerFactory.Create();
                LoadProductsResponse productResponse = productManager.LoadProducts();

                if (productResponse.Success)
                {
                    ConsoleIO.DisplayProducts(productResponse.Products,true);
                }
                else
                {
                    Console.WriteLine(productResponse.Message);
                    return;
                }

                Console.Write($"Enter Product Type({currentOrder.ProductType}): ");
                while (true)
                {
                    int index;
                
                    productType = Console.ReadLine();
                    if (String.IsNullOrEmpty(productType))
                    {
                        productType = currentOrder.ProductType;
                        break;
                    }
                    if (int.TryParse(productType, out index) && (index > 0) && (index <= productResponse.Products.Count))
                    {
                        productType = productResponse.Products[index - 1].ProductType;
                        break;
                    }
                    else
                    {
                        Console.Write("Please enter valid option : ");
                    }
                }

                if (!currentOrder.ProductType.Equals(productType))
                {
                    isEdit = true;
                    currentOrder.ProductType = productType;
                    currentOrder.CostPerSquareFoot = productResponse.Products.Where(i => i.ProductType.Equals(productType)).Select(i => i.CostPerSquareFoot).FirstOrDefault();
                    currentOrder.LaborCostPerSquareFoot = productResponse.Products.Where(i => i.ProductType.Equals(productType)).Select(i => i.LaborCostPerSquareFoot).FirstOrDefault();
                    currentOrder.MaterialCost = decimal.Round((currentOrder.Area * currentOrder.CostPerSquareFoot), 2);
                    currentOrder.LaborCost = decimal.Round((currentOrder.Area * currentOrder.LaborCostPerSquareFoot), 2);
                }
                  

                Console.Write($"\nEnter Area({currentOrder.Area}) (Minimun 100 sq.ft) : ");
                while (true)
                {
                    string input = Console.ReadLine();
                    if (String.IsNullOrEmpty(input))
                    {
                        area = currentOrder.Area;
                        break;
                    }
                    if (!(decimal.TryParse(input, out area) && (area >= 100)))
                    {
                        Console.Write("Please enter valid area : ");
                        continue;
                    }
                    break;
                }

                if (!currentOrder.Area.Equals(area))
                {
                    isEdit = true;
                    currentOrder.Area = area;
                    currentOrder.MaterialCost = decimal.Round((area * currentOrder.CostPerSquareFoot), 2);
                    currentOrder.LaborCost = decimal.Round((area * currentOrder.LaborCostPerSquareFoot), 2);
                    currentOrder.Tax = decimal.Round((currentOrder.MaterialCost + currentOrder.LaborCost) * (currentOrder.TaxRate / 100), 2);
                    currentOrder.Total = decimal.Round((currentOrder.MaterialCost + currentOrder.LaborCost + currentOrder.Tax), 2);
                }

                if (isEdit)
                {
                    ConsoleIO.DisplayOrders(new List<Order>() { currentOrder }, orderDate);

                    Console.Write("\nDo you want to edit order??(Y/N) : ");
                    string input = Console.ReadLine();

                    if (input.ToUpper().Equals("Y"))
                    {
                        Response editOrderResponse = orderManager.EditOrder(orderDate, oldOrder ,currentOrder);
                        if (editOrderResponse.Success)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("\n"+editOrderResponse.Message);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No Change is Order Data.... so no need to edit..");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in EditOrderWorkflow : " + e.Message);
            }
        }

        public void ExecuteEditProduct()
        {
            Console.Clear();
            Console.WriteLine("Edit Product");
            Console.WriteLine(ConsoleIO._seperator);

            Console.Write("Enter Product Type : ");
            string productType = "";
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

            ProductManager productManager = ProductManagerFactory.Create();
            ProductResponse getProductResponse = productManager.GetProduct(productType);
            if (!getProductResponse.Success)
            {
                Console.WriteLine(getProductResponse.Message);
                return;
            }

            Product currentProduct = getProductResponse.Product;
            Console.WriteLine();

            bool isEdit = false;
            decimal costPerSquareFoot, laborCostPerSquareFoot;

            Console.Write($"Enter CostPerSquareFoot({currentProduct.CostPerSquareFoot}): ");
            while (true)
            {
                string input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                {
                    costPerSquareFoot = currentProduct.CostPerSquareFoot;
                    break;
                }
                else if (decimal.TryParse(input,out costPerSquareFoot))
                {
                    if (costPerSquareFoot != currentProduct.CostPerSquareFoot)
                    {
                        isEdit = true;
                    }
                    break;
                }
                else
                {
                    Console.Write("Please Enter CostPerSquareFoot : ");
                }
            }

            Console.Write($"\nEnter LaborCostPerSquareFoot({currentProduct.LaborCostPerSquareFoot}): ");
            while (true)
            {
                string input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                {
                    laborCostPerSquareFoot = currentProduct.LaborCostPerSquareFoot;
                    break;
                }
                else if (decimal.TryParse(input, out laborCostPerSquareFoot))
                {
                    if (laborCostPerSquareFoot != currentProduct.LaborCostPerSquareFoot)
                    {
                        isEdit = true;
                    }
                    break;
                }
                else
                {
                    Console.Write("Please Enter LaborCostPerSquareFoot : ");
                }
            }

            if (isEdit)
            {
                Product _newProduct = new Product
                {
                    ProductType = productType,
                    CostPerSquareFoot = costPerSquareFoot,
                    LaborCostPerSquareFoot = laborCostPerSquareFoot
                };

                ConsoleIO.DisplayProducts(new List<Product> { _newProduct }, false);

                Console.Write("\nDo you want to edit Product ??(Y/N) : ");
                string input = Console.ReadLine();

                if (input.ToUpper().Equals("Y"))
                {
                    Response editProductResponse = productManager.EditProduct(_newProduct,currentProduct);
                    if (editProductResponse.Success)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("\n" + editProductResponse.Message);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Change is Product Data.... so no need to edit..");
            }
        }
        public void ExecuteEditTax()
        {
            Console.Clear();
            Console.WriteLine("Edit Tax");
            Console.WriteLine(ConsoleIO._seperator);

            Console.Write("Enter StateAbbreviation : ");
            string stateAbbreviation = "";
            while (true)
            {
                stateAbbreviation = Console.ReadLine().ToUpper();
                if (!(String.IsNullOrEmpty(stateAbbreviation)) && Regex.IsMatch(stateAbbreviation, "([A-Z]*,|.|[a-z]*,|.|[0-9])*$"))
                {
                    break;
                }
                else
                {
                    Console.Write("Please Enter valid StateAbbreviation : ");
                }
            }

            TaxManager taxManager = TaxManagerFactory.Create();
            TaxResponse taxResponse = taxManager.GetTax(stateAbbreviation);
            if (!taxResponse.Success)
            {
                Console.WriteLine(taxResponse.Message);
                return;
            }

            Tax currentTax = taxResponse.Tax;
            Console.WriteLine();

            bool isEdit = false;
            decimal taxRate;
            string stateName;

            Console.Write($"Enter StateName({currentTax.StateName}): ");
            while (true)
            {
                stateName = Console.ReadLine();
                if (String.IsNullOrEmpty(stateName))
                {
                    stateName= currentTax.StateName;
                    break;
                }
                else if ((stateName != currentTax.StateName) && Regex.IsMatch(stateName, "([A-Z]*,|.|[a-z]*,|.|[0-9])*$"))
                {
                    isEdit = true;
                    break;
                }
                else
                {
                    Console.Write("Please Enter StateName : ");
                }
            }

            Console.Write($"\nEnter TaxRate({currentTax.TaxRate}): ");
            while (true)
            {
                string input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                {
                    taxRate = currentTax.TaxRate;
                    break;
                }
                else if (decimal.TryParse(input, out taxRate))
                {
                    if (taxRate != currentTax.TaxRate)
                    {
                        isEdit = true;
                    }
                    break;
                }
                else
                {
                    Console.Write("Please Enter TaxRate : ");
                }
            }

            if (isEdit)
            {
                Tax _newTax = new Tax
                {
                    StateAbbreviation = stateAbbreviation,
                    StateName = stateName,
                    TaxRate = taxRate
                };

                ConsoleIO.DisplayTaxes(new List<Tax> { _newTax });

                Console.Write("\nDo you want to edit Tax ??(Y/N) : ");
                string input = Console.ReadLine();

                if (input.ToUpper().Equals("Y"))
                {
                    Response editTaxResponse = taxManager.EditTax(_newTax);
                    if (editTaxResponse.Success)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("\n" + editTaxResponse.Message);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Change is Product Data.... so no need to edit..");
            }

        }
    }
}
