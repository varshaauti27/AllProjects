using MyClass.BLL;
using MyClass.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOwnClass.Test
{
    [TestFixture]
    public class BookDataTest
    {
        private const string _filePath = @"\\Mac\Home\Documents\GitHub\net-mpls-0120-classwork-varshaauti27\MyOwnClass.Test\bin\Debug\BookDataTest.txt";
        private const string _originalData = @"\\Mac\Home\Documents\GitHub\net-mpls-0120-classwork-varshaauti27\MyOwnClass.Test\bin\Debug\BookDataTestSeed.txt";
        BookLogic logic;

        [SetUp]
        public void SetUp()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
            File.Copy(_originalData, _filePath);

            logic = new BookLogic(_filePath);
        }

        [Test]
        public void CanReadFromFiles()
        {
            List<Book> books = logic.RetriveAllBookData();
            Assert.AreEqual(4, books.Count());
        }

        [Test]
        public void CanAddBookToFile()
        {
            Book newBook = new Book();

            newBook.Name = "Php";
            newBook.Author = "Balkrushna";
            newBook.BookType = "Language";
            newBook.YearOfPublication = 2020;

            logic.CreateBook(newBook);

            List<Book> books = logic.RetriveAllBookData();
            Assert.AreEqual(5, books.Count());
        }

        [Test]
        public void CanDeleteBookss()
        {
            logic.DeleteSelected(1);
            List<Book> books = logic.RetriveAllBookData();

            Assert.AreEqual(3, books.Count);

            Book check = books[0];
            Assert.AreEqual("C++", check.Name);
        }

        [Test]
        public void CanEditBooks()
        {
            List<Book> books = logic.RetriveAllBookData();
            Book b = books[0];
            b.Author = "RamKrishna";
            logic.EditBook(b);
            Assert.AreEqual(4, books.Count);

            books = logic.RetriveAllBookData();
            Book check = books[0];

            Assert.AreEqual("C#",check.Name);
            Assert.AreEqual("RamKrishna", check.Author);
            Assert.AreEqual("Web", check.BookType);
            Assert.AreEqual(2012, check.YearOfPublication);
        }

        [Test]
        public void CanSearchBookByName()
        {
            List<Book> books = logic.RetriveByBookName("C#");

            Book book = books[0];
            Assert.AreEqual("C#", book.Name);
            Assert.AreEqual("John Paul", book.Author);
            Assert.AreEqual("Web", book.BookType);
        }

        [Test]
        public void CanSearchBookById()
        {
            List<Book> books = logic.RetriveByBookID(2);

            Book book = books[0];
            Assert.AreEqual("C++", book.Name);
            Assert.AreEqual("Balkrisha", book.Author);
            Assert.AreEqual("Language", book.BookType);
        }

        [Test]
        public void CanDeleteAllBooks()
        {
            logic.DeleteAllBooks();

            List<Book> books = logic.RetriveAllBookData();
            Assert.AreEqual(0,books.Count);
        }
    }
}
