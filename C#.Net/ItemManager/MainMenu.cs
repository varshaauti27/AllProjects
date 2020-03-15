using ItemManager.Helper;
using ItemManager.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManager
{
    class MainMenu
    {
        internal static void Show()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                DisplayMenu();
                continueRunning = ProcessChoice();
            }
        }

        private static bool ProcessChoice()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":       // List Book
                    {
                        ListBookWorkflow listBookWorkflow = new ListBookWorkflow();
                        listBookWorkflow.Execute();
                        break;
                    }
                case "2":       // Add Book
                    {
                        AddBookWorkflow addBookWorkflow = new AddBookWorkflow();
                        addBookWorkflow.Execute();
                        break;
                    }
                case "3":
                    {
                        break;
                    }
                case "4":
                    {
                        break;
                    }
                case "Q":
                case "q":
                    {
                        return false;
                    }
                default:
                    {
                        Console.WriteLine(" This is not a valid choice. P;ress anay key to continue...");
                        Console.ReadKey();
                        break;
                    }
            }

            return true;
        }

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("\n Select from following options : ");
            Console.WriteLine(ConsoleDisplay.Seperator);
            Console.WriteLine(" 1. List Books " +
                             "\n 2. Add Book " +
                             "\n 3. Remove Book" +
                             "\n 4. Edit Book ");

            Console.WriteLine("");
            Console.WriteLine(" Q - Quit");
            Console.WriteLine(ConsoleDisplay.Seperator);
            Console.WriteLine("");
            Console.Write(" Enter Choice: ");

            /*Console.WriteLine(" 1) Add Book " +
                              "\t 2) Retrive All " +
                              "\n 3) Retrive One(By Name) " +
                              "\t 4) Retrive One(By ID) " +
                              "\n 5) Update " +
                              "\t 6) Delete All " +
                              "\n 7) Delete selected " +
                              "\t 8) Quit.");
                              */

        }
    }
}
