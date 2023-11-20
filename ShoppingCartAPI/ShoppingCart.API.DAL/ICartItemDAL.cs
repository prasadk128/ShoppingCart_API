using ShoppingCartAPI.Models;
using ShoppingCartAPI.ShoppingCart.API.DTO;
using ShoppingCartAPI.ShoppingCarts.API.Models;
using System.Threading.Tasks;

namespace ShoppingCartAPI.ShoppingCart.API.DAL
{
    public interface ICartItemDAL
    {
        Task<Cart> AddCartItem(CartItem_DTO product);
        Task<Cart> DeleteCartItem(CartItem_DTO cartItem);
        Task<UserCart> GetUserCart(int UserId);
    }
}
