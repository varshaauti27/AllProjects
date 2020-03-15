using MyClass.Data;
using MyClass.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.BLL
{
    public class BookLogic
    {
        readonly IBookRepository bookData;

        public BookLogic(IBookRepository _bookData)
        {
            try
            {
                bookData = _bookData; //new BookData(path);
            }
            catch (FileNotFoundException ex)
            {
                bookData = new BookData();
            }
            catch (Exception ex)
            {
                bookData = new BookData();
            }
            finally
            {

            }
        }
       
        public int CreateBook(string bookName, string author, int year, string bookType)
        {
            try
            {
                Book b = new Book(0, bookName, author, year, bookType);
                return bookData.AddBook(b);
            }
            catch (FileNotFoundException ex)
            {
                return 0;
            }
        }

        public List<Book> RetriveAllBookData()
        {
            try
            {
                return bookData.GetAllBookData();
            }
            catch (FileNotFoundException ex)
            {
                return null;
            }
            finally
            { 
            
            }

        }

        public List<Book> RetriveByBookName(string name)
        {
            try
            {
                return bookData.GetBooksByName(name);
            }
            catch (FileNotFoundException ex)
            {
                return null;
            }
        }

        public List<Book> RetriveByBookID(int id)
        {
            try
            {
                return bookData.GetBookByID(id);
            }
            catch (FileNotFoundException e)
            {
                return null;
            }
        }

        public bool IsBookFound(int id)
        {
            return bookData.IsBookFound(id);
        }

        public void DeleteAllBooks()
        {
            try
            {
                bookData.DeleteAllData();
            }
            catch (Exception ex)
            { 
            
            }
        }

        public bool DeleteSelected(int id)
        {
            try
            {
                return bookData.DeleteSelectedBook(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int CreateBook(Book newBook)
        {
            try
            {
                return bookData.AddBook(newBook);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool EditBook(Book b)
        {
            try
            {
                return bookData.EditBookData(b);
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }    
}