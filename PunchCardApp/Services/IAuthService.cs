using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using PunchCardApp.Models;

namespace PunchCardApp.Services
{
    public interface IAuthService
    {
        Task<string> Authenticate(string email, string password);
    }
}