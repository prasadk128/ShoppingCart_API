using AutoMapper.Configuration.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartAPI.Models
{

    public partial class Cart
    {
      
    
        //cartid,productid,userid --composite primary key
        public int CartId { get; set; }       
      
        public int ProductId { get; set; }
   
        public int UserId { get; set; }

        public int Qunatity { get; set; }
     
        public List<Product> products =new List<Product>();
    }
}
