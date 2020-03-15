using FlooringOrderingSys.Models;
using FlooringOrderingSys.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.Data
{
    public class ProductProdRepository : IProductRepository
    {
        string _filePath;
        public ProductProdRepository(string path)
        {
            _filePath = path;
        }

        public bool AddProduct(Product product)
        {
            try
            {
                List<Product> products;
                products = LoadProducts();

                if (product == null)
                {
                    products = new List<Product>();
                }
                products.Add(product);
                SaveProductsToFile(_filePath, products);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void SaveProductsToFile(string filePath, List<Product> products)
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                writer.WriteLine("ProductType,CostPerSquareFoot,LaborCostPerSquareFoot");
                foreach (Product pro in products)
                {
                    writer.WriteLine(MapProductToLine(pro));
                }
            }
        }

        private string MapProductToLine(Product pro)
        {
            return pro.ProductType + "," + pro.CostPerSquareFoot + "," + pro.LaborCostPerSquareFoot;
        }

        public List<Product> LoadProducts()
        {
            List<Product> products = new List<Product>();
            if (File.Exists(_filePath))
            {
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    reader.ReadLine();

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] props = line.Split(',');
                        products.Add(new Product { ProductType = props[0],
                                                   CostPerSquareFoot = decimal.Parse(props[1]),
                                                   LaborCostPerSquareFoot = decimal.Parse(props[2])
                                                 });
                    }
                }
            }
            return products;
        }

        public Product GetProduct(string productType)
        {
            List<Product> all = LoadProducts();

            if (all != null)
                return all.Where(i => i.ProductType == productType).FirstOrDefault();
            return null;
        }

        public bool EditProduct(Product newProduct)
        {
            try
            {
                List<Product> all = LoadProducts();

                int index = all.FindIndex(i => i.ProductType == newProduct.ProductType);
                if (index != -1)
                {
                    all[index] = newProduct;
                }
                SaveProductsToFile(_filePath, all);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool RemoveProduct(string productType)
        {
            try
            {
                List<Product> all = LoadProducts();

                int index = all.FindIndex(i => i.ProductType == productType);
                all.RemoveAt(index);

                SaveProductsToFile(_filePath, all);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
