using FlooringOrderingSys.Models;
using FlooringOrderingSys.Models.Interfaces;
using FlooringOrderingSys.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.BLL
{
    public class ProductManager
    {
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository repository)
        {
            _productRepository = repository;
        }

        public LoadProductsResponse LoadProducts()
        {
            LoadProductsResponse response = new LoadProductsResponse();

            response.Products = _productRepository.LoadProducts();

            if (response.Products == null)
            {
                response.Success = false;
                response.Message = "No Products found, Unable to get product information !!!!";
            }

            response.Success = true;

            return response;
        }

        public Response AddProduct(Product product)
        {
            Response response = new Response();
            response.Success = _productRepository.AddProduct(product);
            if (response.Success)
            {
                response.Message = "Product Added Successfully !!!!";
            }
            else
            {
                response.Message = "Unable to Add Product !!!!";
            }
            return response;
        }
        public ProductResponse GetProduct(string productType)
        {
            ProductResponse response = new ProductResponse();

            response.Product = _productRepository.GetProduct(productType);

            if (response.Product == null)
            {
                response.Success = false;
                response.Message = "No Product found !!!";
                return response;
            }

            response.Success = true;
            return response;
        }

        public Response EditProduct(Product newProduct,Product oldProduct)
        {
            Response response = new Response();

            response.Success = _productRepository.EditProduct(newProduct);

            if (response.Success)
            {
                response.Message = $"Product {newProduct.ProductType} edited Successfully !!!!";
            }
            else
            {
                response.Message = $"Unable to edit Product{newProduct.ProductType} !!!!";
            }
            return response;
        }

        public Response RemoveProduct(string productType)
        {
            Response response = new Response();

            response.Success = _productRepository.RemoveProduct(productType);

            if (response.Success)
            {
                response.Message = $"Product {productType} removed Successfully !!!!";
            }
            else
            {
                response.Message = $"Unable to remove Product {productType} !!!!";
            }

            return response;
        }
    }
}
