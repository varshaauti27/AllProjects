using FlooringOrderingSys.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.UI
{
    public static class Menu
    {
        //static string _seperator = "*************************************************************************************";
        public static void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Flooring Program : ");
                Console.WriteLine(ConsoleIO._seperator);

                Console.WriteLine("1. Display Orders");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine();
                Console.WriteLine("5. Display Products");
                Console.WriteLine("6. Add an Product");
                Console.WriteLine("7. Edit Product");
                Console.WriteLine("8. Remove Product");
                Console.WriteLine();
                Console.WriteLine("9. Display Taxes");
                Console.WriteLine("10. Add an Taxes");
                Console.WriteLine("11. Edit Taxes");
                Console.WriteLine("12. Remove Taxes");
                Console.WriteLine("13. Quit OR Press 'Q' to exit");
                
                Console.WriteLine();
                Console.WriteLine(ConsoleIO._seperator);
                Console.Write("Enter Option : ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        DisplayWorkflow displayOrderWorkflow = new DisplayWorkflow();
                        displayOrderWorkflow.ExecuteDisplayOrder();
                        break;
                    case "2":
                        AddWorkflow addOrderWorkflow = new AddWorkflow();
                        addOrderWorkflow.ExecuteAddOrder();
                        break;
                    case "3":
                        EditWorkflow editOrderWorkflow = new EditWorkflow();
                        editOrderWorkflow.ExecuteEditOrder();
                        break;
                    case "4":
                        RemoveWorkflow removeOrderWorkflow = new RemoveWorkflow();
                        removeOrderWorkflow.ExecuteRemoveOrder();
                        break;
                    case "5":
                        DisplayWorkflow displayProductWorkflow = new DisplayWorkflow();
                        displayProductWorkflow.ExecuteDisplayProducts();
                        break;
                    case "6":
                        AddWorkflow addProductWorkflow = new AddWorkflow();
                        addProductWorkflow.ExecuteAddProduct();
                        break;
                    case "7":
                        EditWorkflow editProductWorkflow = new EditWorkflow();
                        editProductWorkflow.ExecuteEditProduct();
                        break;
                    case "8":
                        RemoveWorkflow removeProductWorkflow = new RemoveWorkflow();
                        removeProductWorkflow.ExecuteRemoveProduct();
                        break;
                    case "9":
                        DisplayWorkflow displayTaxWorkflow = new DisplayWorkflow();
                        displayTaxWorkflow.ExecuteDisplayTaxes();
                        break;
                    case "10":
                        AddWorkflow addTaxWorkflow = new AddWorkflow();
                        addTaxWorkflow.ExecuteAddTax();
                        break;
                    case "11":
                        EditWorkflow editTaxWorkflow = new EditWorkflow();
                        editTaxWorkflow.ExecuteEditTax();
                        break;
                    case "12":
                        RemoveWorkflow removeTaxWorkflow = new RemoveWorkflow();
                        removeTaxWorkflow.ExecuteRemoveTax();
                        break;
                    case "13":
                    case "Q":
                    case "q":
                        return;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
