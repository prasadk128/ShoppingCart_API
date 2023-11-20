using System.ComponentModel.DataAnnotations;

namespace ShoppingCartAPI.ShoppingCart.API.DTO
{
    public class Product_DTO
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public bool inStock { get; set; }
    }
}
