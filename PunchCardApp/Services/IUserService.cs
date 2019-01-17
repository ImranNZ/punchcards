using System.Collections.Generic;
using System.Threading.Tasks;
using PunchCardApp.Models;

namespace PunchCardApp.Services
{
    public interface IUserService
    {
        Task<User> GetUserAsync(int id);
        Task<List<User>> GetUsersAsync();
        Task<User> CreateUserAsync(User user);
    }
}