using AutoMapper;
using AutoMapper.Internal.Mappers;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.ShoppingCart.API.DTO;
using System;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace ShoppingCartAPI.ShoppingCart.API.DAL
{
    public class UserDAL : IUserDAL
    {
        protected readonly MyShopContext _context;
        public IMapper _mapper;

        public UserDAL(MyShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<User> AddUser(User_DTO user)
        {
            try
            {
                User userEntity = MapUser(user);
                await _context.User.AddAsync(userEntity);
                _context.SaveChanges();
                return userEntity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private User MapUser(User_DTO user)
        {
            return _mapper.Map<User>(user);
        }
    }
}
