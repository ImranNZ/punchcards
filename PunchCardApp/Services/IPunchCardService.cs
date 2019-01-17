using System.Collections.Generic;
using System.Threading.Tasks;
using PunchCardApp.Models;

namespace PunchCardApp.Services
{
    public interface IPunchCardService
    {
        Task<PunchCard> GetPunchCardAsync(int id, int userId);
        Task<List<PunchCard>> GetPunchCardsAsync(int userId);
        Task CreatePunchCardAsync(PunchCard punchCard);
    }
}