using ItemManager.Data;
using ItemManager.Helper;
using ItemManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManager.Workflows
{
    public class ListBookWorkflow
    {
        public void Execute()
        {
            BookRepository repo = new BookRepository(Settings.filePath);
            List<Book> books = repo.List();

        }
    }
}
