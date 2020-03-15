using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.Models.Interfaces
{
    public interface IProductRepository
    {
        List<Product> LoadProducts();

        Product GetProduct(string productType);

        bool AddProduct(Product product);
        bool EditProduct(Product newProduct);
        bool RemoveProduct(string productType);
    }
}
