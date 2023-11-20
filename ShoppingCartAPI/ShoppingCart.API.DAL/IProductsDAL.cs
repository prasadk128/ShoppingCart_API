using ShoppingCartAPI.Models;
using ShoppingCartAPI.ShoppingCart.API.DTO;
using System;
using System.Threading.Tasks;

namespace ShoppingCartAPI.ShoppingCart.API.DAL
{
    public interface IProductsDAL
    {
        Task<Product> AddProduct(Product_DTO product);
    }
}
