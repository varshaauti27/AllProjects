using FlooringOrderingSys.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.BLL
{
    public class ProductManagerFactory
    {
        public static ProductManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new ProductManager(new ProductTestRepository());
                case "Prod":
                    return new ProductManager(new ProductProdRepository(@"\\Mac\Home\Documents\GitHub\net-mpls-0120-classwork-varshaauti27\FlooringOrderingSys\Flooring_Database\Products.txt"));
                case "DB":
                    return new ProductManager(new ProductDBRepository());
                default:
                    throw new Exception("Mode value in App.config is not valid");
            }
        }
    }
}
