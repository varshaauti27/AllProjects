using FlooringOrderingSys.Models;
using FlooringOrderingSys.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.Data
{
    public class ProductTestRepository : IProductRepository
    {
        readonly List<Product> products = new List<Product>() 
                                { 
                                  new Product{ ProductType = "Carpet", CostPerSquareFoot = 2.25M, LaborCostPerSquareFoot = 2.10M },
                                  new Product{ ProductType = "Laminate", CostPerSquareFoot = 1.75M, LaborCostPerSquareFoot = 2.10M },
                                  new Product{ ProductType = "Tile", CostPerSquareFoot = 3.50M, LaborCostPerSquareFoot = 4.15M },
                                  new Product{ ProductType = "Wood", CostPerSquareFoot = 5.15M, LaborCostPerSquareFoot = 4.75M },
                                };

        public bool AddProduct(Product product)
        {
            if (products == null)
                return false;
            products.Add(product);
            return true;
        }

        public bool EditProduct(Product newProduct)
        {
            try
            {
                int index = products.FindIndex(i => i.ProductType == newProduct.ProductType);

                if (index != -1)
                    products[index] = newProduct;
                else
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Product GetProduct(string productType)
        {
            return products.Where(i => i.ProductType == productType).FirstOrDefault();
        }

        public List<Product> LoadProducts()
        {
            return products;
        }

        public bool RemoveProduct(string productType)
        {
            try
            {
                int index = products.FindIndex(i => i.ProductType == productType);
                if (index != -1)
                {
                    products.RemoveAt(index);
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
