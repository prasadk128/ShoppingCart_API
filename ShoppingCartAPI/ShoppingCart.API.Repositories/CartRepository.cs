using ShoppingCartAPI.Models;
using ShoppingCartAPI.ShoppingCart.AP.Infrastructure;
using ShoppingCartAPI.ShoppingCart.API.DAL;
using ShoppingCartAPI.ShoppingCart.API.DTO;
using ShoppingCartAPI.ShoppingCarts.API.Models;
using System;
using System.Threading.Tasks;

namespace ShoppingCartAPI.ShoppingCart.API.Repositories
{

    public class CartRepository:ICartRepository
    {
        protected readonly ICartItemDAL _cartItemtDAL;
        public CartRepository(ICartItemDAL cartItemtDAL)
        {
            _cartItemtDAL = cartItemtDAL;
        }

        public async Task<Cart> AddCartItem(CartItem_DTO cartItem)
        {
            try
            {
                return await _cartItemtDAL.AddCartItem(cartItem);
            }
            catch(Exception ex)
            {
                throw ex;
            }
          
        }
        public async Task<UserCart> GetUserCart(int UserId)
        {
            try
            {
                return await _cartItemtDAL.GetUserCart(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<Cart> DeleteCartItem(CartItem_DTO cartItem)
        {
            try
            {
           return  await   _cartItemtDAL.DeleteCartItem(cartItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
