using FlooringOrderingSys.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.BLL
{
    public class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new OrderManager(new OrderTestRepository());
                case "Prod":
                    return new OrderManager(new OrderProdRepository(@"\\Mac\Home\Documents\GitHub\net-mpls-0120-classwork-varshaauti27\FlooringOrderingSys\Flooring_Database\"));
                case "DB":
                    return new OrderManager(new OrderDBRepository());
                default:
                    throw new Exception("Mode value in App.config is not valid");
            }
        }
    }
}
