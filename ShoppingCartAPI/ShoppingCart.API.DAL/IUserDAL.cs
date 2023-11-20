using ShoppingCartAPI.Models;
using ShoppingCartAPI.ShoppingCart.API.DTO;
using System.Threading.Tasks;

namespace ShoppingCartAPI.ShoppingCart.API.DAL
{
    public interface IUserDAL
    {
        Task<User> AddUser(User_DTO user);

    }
}
