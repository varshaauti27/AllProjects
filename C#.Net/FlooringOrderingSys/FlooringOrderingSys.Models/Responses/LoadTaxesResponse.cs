using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.Models.Responses
{
    public class LoadTaxesResponse : Response
    {
        public List<Tax> Taxes { get; set; }
    }
}
