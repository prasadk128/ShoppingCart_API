using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartAPI.Models
{
    public partial class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

       

        [Required]

        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public decimal? Price { get; set; }
        public bool inStock { get; set; }
    }
}
