using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClass.Model;

namespace MyClass.Data
{
    public class BookData : IBookRepository
    {
        readonly Dictionary<int, Book> allBooks = new Dictionary<int, Book>();
        int _nextBookId;
        readonly string Path="BookData.txt";

        public BookData()
        {
            _nextBookId += 1;
        }
        public BookData(string path)
        {
            Path = path;
            if (File.Exists(Path))
            {
                List<Book> list = ReadAllBooks();
                foreach (Book m in list)
                {
                    allBooks.Add(m.BookId, m);
                    _nextBookId = m.BookId; 
                }
            }
            /*else
            {
                /*
                1 | C# | John Paul | Web | 2012
2 | C++ | Balkrisha | Language | 2013
3 | Java | Agrawal | Language | 2014
4 | Php | Krishnamurti | Web | 2010 

                allBooks.Add(1, new Book() { BookId = 1, Name = "C#", Author = "John Paul", YearOfPublication = 2012, BookType = "Web" });
                allBooks.Add(2, new Book() { BookId = 2, Name = "C++", Author = "Balkrisha", YearOfPublication = 2013, BookType = "Language" });
                allBooks.Add(3, new Book() { BookId = 3, Name = "Java", Author = "Agrawal", YearOfPublication = 2014, BookType = "Language" });
                allBooks.Add(4, new Book() { BookId = 4, Name = "Php", Author = "Krishnamurti", YearOfPublication = 2010, BookType = "Web" });

                WriteBookToFile(allBooks);
                _nextBookId = allBooks.Count;
            }*/
            _nextBookId += 1;
        }

        public int AddBook(Book newBook)
        {
            newBook.BookId = _nextBookId;
            allBooks.Add(_nextBookId, newBook);
            WriteBookToFile(allBooks);
            _nextBookId++;
            return newBook.BookId;
        }

        public bool EditBookData(Book b)
        {
            allBooks[b.BookId] = b;
            WriteBookToFile(allBooks);
            return true;
        }

        private void WriteBookToFile(Dictionary<int, Book> allBooks)
        {
            using (StreamWriter writer = new StreamWriter(Path))
            {
                foreach (var item in allBooks)
                {
                    writer.WriteLine(MapBankDataToLine(item.Value));
                }
            }
        }

        private string MapBankDataToLine(Book value)
        {
            return value.BookId + " | " + value.Name + " | " + value.Author + " | " + value.BookType + " | " + value.YearOfPublication;
        }

        private List<Book> ReadAllBooks()
        {
            List<Book> b = new List<Book>();
            using (StreamReader reader = new StreamReader(Path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    b.Add(MapLineToBookData(line));
                }
            }
            return b;
        }

        private Book MapLineToBookData(string line)
        {
            string[] data = line.Split('|');
            Book bank = new Book(int.Parse(data[0].Trim()), data[1].Trim(), data[2].Trim(), int.Parse(data[4].Trim()), data[3].Trim());
            return bank;
        }

        public List<Book> GetBooksByName(string name)
        {
            return allBooks.Values.Where(b => b.Name.ToUpper() == name).ToList();
        }

        public bool IsFound(int id)
        {
            return allBooks.ContainsKey(id);
        }

        public void DeleteAllData()
        {
            allBooks.Clear();
            _nextBookId = 1;
            WriteBookToFile(allBooks);
        }

        public bool DeleteSelectedBook(int id)
        {
            bool isDeleted = false;
            if (allBooks.Remove(id))
            {
                isDeleted = true;
                WriteBookToFile(allBooks);
            }
            return isDeleted;
        }

        public List<Book> GetBookByID(int id)
        {
            return allBooks.Values.Where(b => b.BookId == id).ToList();
        }

        public List<Book> GetAllBookData()
        {
            return allBooks.Values.ToList();
        }

        public int AddBook(string bookName, string author, int year, string bookType)
        {
            int bookId = _nextBookId;
            allBooks.Add(_nextBookId, new Book(_nextBookId,bookName, author, year, bookType));
            WriteBookToFile(allBooks);
            _nextBookId++;
            return bookId;
        }

        public bool IsBookFound(int id)
        {
            return allBooks.ContainsKey(id);
        }
    }
}