using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingList.BLL;
using ShoppingList.Model;

namespace ShoppingList.UI
{
    class Program
    {
        static HandleShoppingList handle = new HandleShoppingList();
        static void Main(string[] args)
        {
            bool toContinue = true;
            int option;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Select from te following options :" +
                    "\n 1) Display Shopping List "+
                    "\t 2) Add Item " +
                    "\n 3) Delete Item(By ID) " +
                    "\t 4) Delete All items "+
                    "\n 5) Search Item(By ID)" +
                    "\t 6) Search Item(By Name)" +
                    "\n 7) Edit Item " +
                    "\t 8) Quit.");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n Choose your option : ");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out option))
                    {
                        switch (option)
                        {
                            case 1:         // Display Shopping List... 
                                {
                                    Console.Write(" Displaying Shopping List .....");
                                    Display();
                                    break;
                                }
                            case 2:         // Add item Shopping List... 
                                {
                                    Console.WriteLine("\n Enter item Details :");
                                    Console.Write(" Item Name : ");
                                    string name = Console.ReadLine();
                                    Console.Write(" Item Quantity : ");
                                    int quantity;
                                    while (true)
                                    {
                                        if (int.TryParse(Console.ReadLine(), out quantity))
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.Write(" Please enter valid quantity : ");
                                        }
                                    }
                                    Console.WriteLine(handle.AddItemToShoppingList(name, quantity));
                                    break;
                                }
                            case 3:             // Delete item By ID
                                {
                                    int id;
                                    Console.Write("\n Enter item Id to be deleted : ");
                                    while (true)
                                    {
                                        if (int.TryParse(Console.ReadLine(), out id))
                                        {
                                            if (handle.IsListContainsItem(id))
                                            {
                                                if (handle.RemoveItemById(id))
                                                    Console.WriteLine($" Succsessfully Removed item{id} !!!!");
                                                else
                                                    Console.WriteLine($" Unable to Remove item{id} from the list");
                                            }
                                            else
                                            {
                                                Console.WriteLine($" There is No item with Id {id}");
                                            }
                                            break;
                                        }
                                        else
                                        {
                                            Console.Write(" PLease Enter Valid ID : ");
                                        }
                                    }
                                    break;
                                }
                            case 4:             // Delete All items
                                {
                                    Console.Write(" Deleting All items....");
                                    handle.DeleteAllList();
                                    break;
                                }
                            case 5:             //Search Item By ID
                                {
                                    int id;
                                    Console.Write("\n Enter Id : ");
                                    while (true)
                                    {
                                        if (int.TryParse(Console.ReadLine(), out id))
                                        {
                                            if (handle.IsListContainsItem(id))
                                            {
                                                Item data;
                                                data = handle.SearchItemsById(id);
                                                if (data != null)
                                                    Display(data);
                                                else
                                                    Console.WriteLine($" No Item{id} found !!!");
                                            }
                                            break;
                                        }
                                        else
                                        { 
                                        
                                        }
                                    }
                                    break;
                                }
                            case 6:             //Search By Name
                                {
                                    Console.Write("\n Enter Name : ");
                                    string name = Console.ReadLine();
                                    Item data;
                                    data = handle.SearchItemByName(name.ToUpper().Trim());
                                    if (data != null)
                                        Display(data);
                                    else
                                        Console.WriteLine($" No Item {name} found !!!");
                                    break;
                                }
                            case 7:
                                {
                                    int id;
                                    Console.WriteLine(" Editing items.....");
                                    Console.Write("\n Enter Item Id : ");
                                    while (true)
                                    {
                                        if (int.TryParse(Console.ReadLine(), out id))
                                        {
                                            if (handle.IsListContainsItem(id))
                                            {
                                                Console.Write(" Enter Item Quantity : ");
                                                if (int.TryParse(Console.ReadLine(), out int q))
                                                {
                                                    handle.EditShoppingItem(id,q);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($" Item with Id {id} Not Found !!!");
                                            }
                                            break;
                                        }
                                        else
                                        {
                                            Console.Write(" Please enter valid Id : ");
                                        }
                                    }
                                    break;
                                }
                            case 8:
                                {
                                    System.Environment.Exit(1);
                                    break;
                                }
                            default:
                                break;
                        }
                        break;
                    }
                    else
                    {
                        Console.Write(" Please choose valid option : ");
                        continue;
                    }
                }
                Console.Write("\n Do you want to continue??(Y/N) ");
                if (Console.ReadLine().ToUpper().Equals("N"))
                    toContinue = false;
            } while (toContinue);
        }

        private static void Display(Item data)
        {
            string format = " {0,-10}{1,-20}{2,-20}";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine(format, "Item Id", "Name", "Quantity");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("---------------------------------------------------");

            Console.WriteLine(format, data.ID, data.Name, data.Quantity);
            Console.WriteLine("---------------------------------------------------");
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Display()
        {
            List<Item> items = new List<Item>();
            items = handle.GetShoppingList();
            string format = " {0,-10}{1,-20}{2,-20}";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine(format,"Item Id","Name","Quantity");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("---------------------------------------------------");
            foreach (Item i in items)
            {
                Console.WriteLine(format,i.ID,i.Name,i.Quantity);
                Console.WriteLine("---------------------------------------------------");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
