using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string BookType { get; set; }
        public int YearOfPublication { get; set; }

        public Book()
        { 
        
        }
        public Book(int bookId,string bookName, string authorName, int year, string bookType)
        {
            BookId = bookId;
            Name = bookName;
            Author = authorName;
            BookType = bookType;
            YearOfPublication = year;
        }
    }
}