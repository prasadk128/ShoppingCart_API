using ShoppingCartAPI.Models;
using ShoppingCartAPI.ShoppingCart.API.DTO;
using System.Threading.Tasks;

namespace ShoppingCartAPI.ShoppingCart.AP.Infrastructure
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product_DTO product);
    }
}
