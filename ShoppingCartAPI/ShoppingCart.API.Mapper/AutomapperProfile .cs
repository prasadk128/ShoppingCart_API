using AutoMapper;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.ShoppingCart.API.DTO;

namespace ShoppingCartAPI.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User_DTO, User>();
            CreateMap<Product_DTO, Product>();
            CreateMap<CartItem_DTO, Cart>();
        }
    }
}
