using FlooringOrderingSys.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.BLL
{
    public class TaxManagerFactory
    {
        public static TaxManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new TaxManager(new TaxTestRepository());
                case "Prod":
                    return new TaxManager(new TaxProdRepository(@"\\Mac\Home\Documents\GitHub\net-mpls-0120-classwork-varshaauti27\FlooringOrderingSys\Flooring_Database\Taxes.txt"));
                case "DB":
                    return new TaxManager(new TaxDBRepository());
                default:
                    throw new Exception("Mode value in App.config is not valid");
            }
        }
    }
}
