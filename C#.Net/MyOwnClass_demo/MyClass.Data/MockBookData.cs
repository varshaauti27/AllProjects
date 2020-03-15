using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Data
{
    public class MockBookData : IBookRepository
    {
        private static Dictionary<int, Book> _books = new Dictionary<int, Book>();
        int _nextBookId;

        public MockBookData()
        {
            if (!_books.Any())
            {
                _books.Add(1, new Book() { BookId = 1, Name = "C#", Author = "John Paul", YearOfPublication = 2012, BookType = "Web" });
                _books.Add(2, new Book() { BookId = 2, Name = "C++", Author = "Balkrisha", YearOfPublication = 2013, BookType = "Language" });
                _books.Add(3, new Book() { BookId = 3, Name = "Java", Author = "Agrawal", YearOfPublication = 2014, BookType = "Language" });
                _books.Add(4, new Book() { BookId = 4, Name = "Php", Author = "Krishnamurti", YearOfPublication = 2010, BookType = "Web" });
                _nextBookId = _books.Count() + 1;
            }
        }

        public int AddBook(Book newBook)
        {
            newBook.BookId = _nextBookId;
            _books.Add(_nextBookId, newBook);
            _nextBookId++;
            return newBook.BookId;
        }

        public void DeleteAllData()
        {
            _books.Clear();
            _nextBookId = 1;
        }

        public bool DeleteSelectedBook(int id)
        {
            bool isDeleted = false;
            if (_books.Remove(id))
            {
                isDeleted = true;
            }
            return isDeleted;
        }

        public bool EditBookData(Book b)
        {
            _books[b.BookId] = b;
            return true;
        }

        public List<Book> GetAllBookData()
        {
            return _books.Values.ToList();
        }

        public List<Book> GetBookByID(int id)
        {
            return _books.Values.Where(b => b.BookId == id).ToList();
        }

        public List<Book> GetBooksByName(string name)
        {
            return _books.Values.Where(b => b.Name.ToUpper() == name).ToList();
        }

        public bool IsBookFound(int id)
        {
            return _books.ContainsKey(id);
               
        }
    }
}
