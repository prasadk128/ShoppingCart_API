using ShoppingCartAPI.Models;
using ShoppingCartAPI.ShoppingCart.AP.Infrastructure;
using ShoppingCartAPI.ShoppingCart.API.DAL;
using ShoppingCartAPI.ShoppingCart.API.DTO;
using System;
using System.Threading.Tasks;

namespace ShoppingCartAPI.ShoppingCart.API.Repositories
{
    public class ProductRepository:IProductRepository
    {
        protected readonly IProductsDAL _productDAL;
        public ProductRepository(IProductsDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public async Task<Product> AddProduct(Product_DTO product)
        {
            try
            {
                return await _productDAL.AddProduct(product);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
