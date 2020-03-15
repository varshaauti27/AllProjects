using ItemManager.Helper;
using ItemManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManager.Workflows
{
    public class AddBookWorkflow
    {
        internal void Execute()
        {
            Console.Clear();
            Console.WriteLine("Add Book : ");
            Console.WriteLine(ConsoleDisplay.Seperator);
            Console.WriteLine();


            Book newBook = new Book();
        }
    }
}
