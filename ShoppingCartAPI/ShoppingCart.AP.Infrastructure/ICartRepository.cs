using ShoppingCartAPI.Models;
using ShoppingCartAPI.ShoppingCart.API.DTO;
using ShoppingCartAPI.ShoppingCarts.API.Models;
using System.Threading.Tasks;

namespace ShoppingCartAPI.ShoppingCart.AP.Infrastructure
{
    public interface ICartRepository
    {
        Task<Cart> AddCartItem(CartItem_DTO cartItem);
        Task<Cart> DeleteCartItem(CartItem_DTO cartItem);
        Task<UserCart> GetUserCart(int UserId);
    }
}
