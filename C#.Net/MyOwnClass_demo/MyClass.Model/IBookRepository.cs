using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    public interface IBookRepository
    {
        int AddBook(Book newBook);
        List<Book> GetAllBookData();
        List<Book> GetBooksByName(string name);
        List<Book> GetBookByID(int id);
        bool EditBookData(Book b);
        void DeleteAllData();
        bool DeleteSelectedBook(int id);
        bool IsBookFound(int id);

    }
}
