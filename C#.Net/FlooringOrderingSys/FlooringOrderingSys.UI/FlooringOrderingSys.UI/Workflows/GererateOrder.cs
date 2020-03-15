using FlooringOrderingSys.Models;
using FlooringOrderingSys.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.UI.Workflows
{
    public static class GererateOrder
    {
        public static Order Create(string custName, string state, string productType,decimal area, LoadTaxesResponse taxesResponse, LoadProductsResponse productResponse)
        {
            decimal taxRate = taxesResponse.Taxes.Where(i => i.StateAbbreviation.Equals(state)).Select(i => i.TaxRate).FirstOrDefault();
            decimal costPerSqaureFoot = productResponse.Products.Where(i => i.ProductType.Equals(productType)).Select(i => i.CostPerSquareFoot).FirstOrDefault();
            decimal laborCostPerSquareFoot = productResponse.Products.Where(i => i.ProductType.Equals(productType)).Select(i => i.LaborCostPerSquareFoot).FirstOrDefault();

            decimal materialCost = decimal.Round((area * costPerSqaureFoot),2);
            decimal laborCost = decimal.Round((area * laborCostPerSquareFoot),2);
            decimal tax = decimal.Round((materialCost + laborCost) * (taxRate / 100),2);
            decimal total = decimal.Round((materialCost + laborCost + tax),2);

            Order _order = new Order()
            {
                CustomerName = custName,
                State = state,
                TaxRate = taxRate,
                ProductType = productType,
                Area = area,
                CostPerSquareFoot = costPerSqaureFoot,
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
