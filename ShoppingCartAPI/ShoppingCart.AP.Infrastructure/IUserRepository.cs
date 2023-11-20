using ShoppingCartAPI.Models;
using ShoppingCartAPI.ShoppingCart.API.DTO;
using System.Threading.Tasks;

namespace ShoppingCartAPI.Infrastructure
{
    public interface IUserRepository
    {
        Task<User> AddUser(User_DTO user);
    }
}
