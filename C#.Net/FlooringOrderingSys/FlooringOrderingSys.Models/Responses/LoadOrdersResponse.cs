using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.Models.Responses
{
    public class LoadOrdersResponse : Response
    {
        public DateTime OrderDate { get; set; }
        public List<Order> Orders { get; set; }
    }
}