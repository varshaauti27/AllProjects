using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.Models.Interfaces
{
    public interface ITaxRepository 
    {
        List<Tax> LoadTaxes();
        bool AddTax(Tax tax);
        Tax GetTax(string stateAbbreviation);
        bool EditTax(Tax newTax);
        bool RemoveTax(string stateAbbreviation);
    }
}
