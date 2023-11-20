using ShoppingCartAPI.Infrastructure;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.ShoppingCart.API.DAL;
using ShoppingCartAPI.ShoppingCart.API.DTO;
using System;
using System.Threading.Tasks;

namespace ShoppingCartAPI.Repositories
{
    public class UserRepository : IUserRepository

    {
        protected readonly IUserDAL _userDAl;

        public UserRepository(IUserDAL userDAL) {
            _userDAl=userDAL;
        }

          public async Task<User> AddUser(User_DTO user)
        {
            try
            {
                return await _userDAl.AddUser(user);
            }
            catch (Exception ex)
            {

                // Return a custom error response to the user
                throw ex;
            }
        }
    }
}
