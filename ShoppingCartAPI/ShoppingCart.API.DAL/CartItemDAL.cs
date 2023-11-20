using ShoppingCartAPI.ShoppingCart.API.DTO;
using ShoppingCartAPI.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System;
using Microsoft.CodeAnalysis;
using ShoppingCartAPI.ShoppingCarts.API.Models;
using System.Collections.Generic;

namespace ShoppingCartAPI.ShoppingCart.API.DAL
{
    public class CartItemDAL : ICartItemDAL
    {

        protected readonly MyShopContext _context;
        public IMapper _mapper;
        public CartItemDAL(MyShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<Cart> AddCartItem(CartItem_DTO cartItem)
        {
            
           
            try
            {
                var cartItemEntity = new Cart
                {
                    CartId = 1,
                    ProductId = cartItem.ProductId,
                    UserId = cartItem.UserId,
                    Qunatity = cartItem.Qunatity
                };
                var cartItemxisted = await _context.Cart.Where(x => x.UserId == cartItem.UserId && x.ProductId == cartItem.ProductId).FirstOrDefaultAsync();
                if (cartItemxisted == null)
                {
                   
                    await _context.Cart.AddAsync(cartItemEntity);
                }
                else

                    cartItemxisted.Qunatity += cartItem.Qunatity;
                _context.SaveChanges();
                return cartItemxisted;
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

                var cartItemEntity = await _context.Cart.Where(x => x.UserId == cartItem.UserId && x.ProductId == cartItem.ProductId).ToListAsync();
                var itemCart = cartItemEntity.FirstOrDefault();
                if (cartItem != null && itemCart.Qunatity >= itemCart.Qunatity)
                {
                    // Update the quantity
                    itemCart.Qunatity -= cartItem.Qunatity; // or any other logic to update the quantity

                    // Save changes to the database
                    _context.SaveChanges();
                }
                return itemCart;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<UserCart> GetUserCart(int UserId)
        {
            try
            {
                List<Cart> lstCart = await getCart(UserId);
                if(lstCart.Count ==0)
                    return null;
                var res = await _context.Cart.Where(x => x.UserId == UserId).Select(x => x.ProductId).ToListAsync();
                var products = await _context.Product.Where(x => res.Contains(x.Id)).ToListAsync();
                List<CartProduct> crtProducts = new List<CartProduct>();

                foreach (var item in products)
                {
                    CartProduct lstCartItem = new CartProduct();
                    var qty = lstCart.FirstOrDefault(x => x.ProductId == item.Id).Qunatity;
                    lstCartItem.Id = item.Id;
                    lstCartItem.Name = item.Name;
                    lstCartItem.Price = item.Price * qty;
                    lstCartItem.qty = qty;
                    crtProducts.Add(lstCartItem);
                }
                return new UserCart
                {
                    UserId = UserId,
                    CartId = lstCart.FirstOrDefault().CartId,
                    cartproducts = crtProducts
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

            async Task<List<Cart>> getCart(int UserId)
            {
                return await _context.Cart.Where(x => x.UserId == UserId).ToListAsync();
            }
        }


    }
}

