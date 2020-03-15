using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.Models.Responses
{
    public class LoadProductsResponse : Response
    {
        public List<Product> Products { get; set; }
    }
}
