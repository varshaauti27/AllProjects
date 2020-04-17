using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class ContactManager
    {
        public static IContactRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "QA":
                    return new ContactMockRepository();
                case "ADO":
                    return new ContactADORepository();
                default:
                    throw new Exception("Mode value in App.config is not valid");
            }
        }
    }
}