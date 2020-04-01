using DVDLibraryWebAPI.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace DVDLibraryWebAPI.Data
{
    public class DVDFactory
    {
        public static IDvdRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "SampleData":
                    return new DvdRepositoryMock();
                case "EntityFramework":
                    return new DvdRepositoryEF();
                case "ADO":
                    return new DvdRepositoryADO();
                default:
                    throw new Exception("Mode value in App.config is not valid");
            }
        }
    }
}