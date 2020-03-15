using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClass.BLL;
using MyClass.Model;

namespace MyOwnClass
{
    class Program
    {
        static readonly BookLogic bookLogic = Factory.CreateBookRepository();
        static readonly string TableSeperator = "---------------------------------------------------------------------------------------------";
        static readonly string Seperator = "============================================";
        static readonly string format = " {0,-5}|  {1,-15}|  {2,-15}|  {3,-15}|  {4,-15}";
        static void Main(string[] args)
        {
            int option;
            bool toContinue = true;
            do
            {
                DisplayMenu();
                Console.Write("\n Enter your choice : ");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out option))
                    {
                        break;
                    }
                    else
                    {
                        Console.Write(" Enter valid choice : ");
                    }
                }
                ExecuteMethods(option);
                Console.Write("\n Do you want to continue?(Y/N) : ");
                if (Console.ReadLine().ToUpper().Equals("N"))
                {
                    toContinue = false;
                }
            } while (toContinue);

            Console.ReadKey();
        }

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n Item Manager ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Seperator);
            Console.WriteLine(" Select from following options : ");

            Console.WriteLine("\n\t 1) Add Book " +
                              "\n\t 2) Retrive All " +
                              "\n\t 3) Retrive One(By Name) " +
                              "\n\t 4) Retrive One(By ID) " +
                              "\n\t 5) Update " +
                              "\n\t 6) Delete All " +
                              "\n\t 7) Delete selected ");

            Console.WriteLine();
            Console.WriteLine(" Q - Quit");
            //Console.WriteLine();
            Console.WriteLine(Seperator);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void ExecuteMethods(int opt)
        {
            switch (opt)
            {
                case 1:             // Create  
                    {
                        AddBook();
                        break;
                    }
                case 2:             // Retrive All
                    {
                        RetriveAll();
                        break;
                    }
                case 3:             // Retrive One By Name
                    {
                        RetriveBookByName();
                        break;
                    }
                case 4:             // Retrive One by ID
                    {
                        RetriveBookById();
                        break;
                    }
                case 5:             // Update
                    {
                        UdpateBook();
                        break;
                    }
                case 6:             // Delete All
                    {
                        Console.WriteLine(" Deleting All Books Data....");
                        bookLogic.DeleteAllBooks();
                        break;
                    }
                case 7:             // Delete 
                    {
                        int id;
                        Console.Write("\n Enter Book ID : ");
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out id))
                            {
                                if (bookLogic.IsBookFound(id))
                                {
                                    if (bookLogic.DeleteSelected(id))
                                        Console.WriteLine($" Book({id}) deleted successfully !!!!");
                                    else
                                        Console.WriteLine($" Unable to delete Book({id}) !!!!");
                                }
                                else
                                {
                                    Console.WriteLine($" No book found with ID({id}) !!!!");
                                }
                                break;
                            }
                            else
                            {
                                Console.Write(" Please Enter Valid Book ID : ");
                            }
                        }
                        break;
                    }
                case 8:             // Quit
                    {
                        System.Environment.Exit(0);
                        break;
                    }
                default:
                    {
                        Console.WriteLine(" No Option found !!!!");
                        break;
                    }
            }
        }

        private static void UdpateBook()
        {
            List<Book> books =  bookLogic.RetriveAllBookData();
            DisplayBooks(books);

            int id;
            Console.Write(" Enter Book Id for book you want to update : ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    if (bookLogic.IsBookFound(id))
                    {
                        Book b = new Book();
                        b.BookId = id;
                        Console.Write(" Book Name : ");
                        b.Name = Console.ReadLine();
                        Console.Write(" Author : ");
                        b.Author = Console.ReadLine();
                        Console.Write(" Type : ");
                        b.BookType = Console.ReadLine();
                        Console.Write(" Year : ");
                        b.YearOfPublication = int.Parse(Console.ReadLine());

                        if (bookLogic.EditBook(b))
                            Console.WriteLine($" Book({id}) updated successfully !!!!");
                        else
                            Console.WriteLine($" Unable to Update Book({id}) !!!!");
                    }
                    else
                    {
                        Console.WriteLine($" No book found with ID({id}) !!!!");
                    }
                    break;
                }
                else
                {
                    Console.Write(" Please Enter Valid Book ID : ");
                }
            }
        }

        private static void RetriveBookById()
        {
            int id;
            Console.Write("\n Enter Book ID : ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    if (bookLogic.IsBookFound(id))
                    {
                        List<Book> data = bookLogic.RetriveByBookID(id);
                        DisplayBooks(data);
                        break;
                    }
                    else
                    {
                        Console.WriteLine($" No book found with ID({id}) !!!!");
                    }
                }
                else
                {
                    Console.Write(" Please Enter Valid Book ID : ");
                }
            }
        }

        private static void RetriveBookByName()
        {
            //RetriveAll();
            Console.Write("\n Enter Book Name : ");
            string name = Console.ReadLine();
            List<Book> books = bookLogic.RetriveByBookName(name.ToUpper());
            if (books.Count > 0)
                DisplayBooks(books);
            else
                Console.WriteLine(" No Book Found !!!!ss");
        }

        private static void RetriveAll()
        {
            List<Book> data = bookLogic.RetriveAllBookData();
            DisplayBooks(data);        
        }

        private static void DisplayBooks(List<Book> data)
        {
            if (data.Count < 0)
            {
                Console.WriteLine(" No Books Found !!!!");
                return;
            }
            DisplayBookHeader();
            foreach (Book item in data)
            {
                Console.WriteLine(format, item.BookId, item.Name, item.Author, item.BookType, item.YearOfPublication);
            }
            Console.WriteLine(TableSeperator);
        }

        
        private static void DisplayBookHeader()
        {
            Console.WriteLine(TableSeperator);
            Console.WriteLine(format, "ID", "Name", "Author", "Book Type", "Year of publications");
            Console.WriteLine(TableSeperator);
        }

        private static void AddBook()
        {
            Book newBook = new Book() ;
            Console.Clear();
            Console.WriteLine(" Add Book :");
            Console.WriteLine(Seperator);
            Console.WriteLine("\n Enter book details : ");
            Console.Write(" Book Name : ");
            newBook.Name = Console.ReadLine();
            Console.Write(" Author : ");
            newBook.Author = Console.ReadLine();
            Console.Write(" Book Type : ");
            newBook.BookType = Console.ReadLine();
            Console.Write(" Year : ");
            newBook.YearOfPublication = int.Parse(Console.ReadLine());

            Console.WriteLine("\n Do you want to Add following Book : ");
            DisplayBook(newBook);

            Console.Write("\n Confirm (Y/N)? : ");
            if (!(Console.ReadLine().ToUpper().Equals("N")))
            {
                int id = bookLogic.CreateBook(newBook);
                Console.WriteLine($"\n {newBook.Name} Book is Added with Id {id}");
            }
        }

        private static void DisplayBook(Book newBook)
        {
            DisplayBookHeader();
            Console.WriteLine(format, " ",newBook.Name, newBook.Author, newBook.BookType, newBook.YearOfPublication);
        }
    }
}