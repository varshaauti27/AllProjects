using ItemManager.Helper;
using ItemManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManager.Data
{
    public class BookRepository
    {
        private string filePath;

        public BookRepository(string filePath)
        {
            this.filePath = filePath;
        }

        internal List<Book> List()
        {
            List<Book> books = new List<Book>();

            using (StreamReader sr = new StreamReader(Settings.filePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Book newBook = new Book();

                    string[] columns = line.Split(',');

                    newBook.BookName = columns[0];
                    newBook.Author = columns[1];
                    newBook.Type = columns[2];
                    newBook.NoOfPages =int.Parse(columns[3]);
                    newBook.YearPublished = DateTime.Parse(columns[4]);

                    books.Add(newBook);
                }
            }

            return books;
        }
    }
}
