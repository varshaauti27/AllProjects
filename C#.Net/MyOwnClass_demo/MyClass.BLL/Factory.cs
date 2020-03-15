using MyClass.Data;
using MyClass.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.BLL
{
    public static class Factory
    {
        public static BookLogic CreateBookRepository()
        {
            switch(ConfigurationManager.AppSettings["mode"].ToLower())
            {
                case "prod":
                    return new BookLogic(new BookData("BookData.txt"));
                case "mock":
                    return new BookLogic(new MockBookData());

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
