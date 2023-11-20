using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace ShoppingCartAPI.ShoppingCarts.API.Models
{
    public class CartProduct
    {
       
        public int Id { get; set; }
        public string Name { get; set; }


        public decimal? Price { get; set; }
     
       public int qty { get; set; }
    }
}
