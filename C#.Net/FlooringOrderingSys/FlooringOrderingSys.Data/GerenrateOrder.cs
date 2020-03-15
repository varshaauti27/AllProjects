using FlooringOrderingSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.Data
{
    static class GererateOrder
    {
        public static Order Create(string custName, string state, string productType, decimal area,
                                   decimal costPerSquareFoot,decimal laborCostPerSquareFoot,decimal taxRate)
        {
            decimal materialCost = decimal.Round((area * costPerSquareFoot), 2);
            decimal laborCost = decimal.Round((area * laborCostPerSquareFoot), 2);
            decimal tax = decimal.Round((materialCost + laborCost) * (taxRate / 100), 2);
            decimal total = decimal.Round((materialCost + laborCost + tax), 2);

            Order _order = new Order()
            {
                CustomerName = custName,
                State = state,
                TaxRate = taxRate,
                ProductType = productType,
                Area = area,
                CostPerSquareFoot = costPerSquareFoot,
                LaborCostPerSquareFoot = laborCostPerSquareFoot,
                MaterialCost = materialCost,
                LaborCost = laborCost,
                Tax = tax,
                Total = total
            };
            return _order;
        }
    }
}
