using ShoppingCartAPI.Models;
using System.Collections.Generic;

namespace ShoppingCartAPI.ShoppingCarts.API.Models
{
    public class UserCart
    {

        public int UserId { get; set; }
        public int CartId { get; set; }          
        public List<CartProduct> cartproducts { get; set; }
    }
}
