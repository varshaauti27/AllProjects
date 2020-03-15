using FlooringOrderingSys.Models;
using FlooringOrderingSys.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.Data
{
    public class TaxTestRepository : ITaxRepository
    {
        readonly List<Tax> taxes = new List<Tax>()
                            {
                                new Tax(){ StateAbbreviation = "OH",StateName = "Ohio" ,TaxRate = 6.25M},
                                new Tax(){ StateAbbreviation = "PA",StateName = "Pennsylvania" ,TaxRate = 6.75M},
                                new Tax(){ StateAbbreviation = "MI",StateName = "Michigan" ,TaxRate = 5.75M},
                                new Tax(){ StateAbbreviation = "IN",StateName = "Indiana" ,TaxRate = 6.00M},
                            };

        public bool AddTax(Tax tax)
        {
            if (taxes == null)
                return false;
            taxes.Add(tax);
            return true;
        }

        public bool EditTax(Tax newTax)
        {
            try
            {
                int index = taxes.FindIndex(i => i.StateAbbreviation == newTax.StateAbbreviation);

                if (index != -1)
                    taxes[index] = newTax;
                else
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Tax GetTax(string stateAbbreviation)
        {
            return taxes.Where(i => i.StateAbbreviation == stateAbbreviation).FirstOrDefault();
        }

        public List<Tax> LoadTaxes()
        {
            return taxes;
        }

        public bool RemoveTax(string stateAbbreviation)
        {
            try
            {
                int index = taxes.FindIndex(i => i.StateAbbreviation == stateAbbreviation);
                if (index != -1)
                {
                    taxes.RemoveAt(index);
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
