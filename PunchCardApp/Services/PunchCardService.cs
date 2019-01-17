using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PunchCardApp.Data;
using PunchCardApp.Models;

namespace PunchCardApp.Services
{
    public class PunchCardService : IPunchCardService
    {
        private readonly PunchCardAppContext _context;

        public PunchCardService(PunchCardAppContext context)
        {
            _context = context;
        }

        public async Task<PunchCard> GetPunchCardAsync(int id, int userId)
        {
            var punchCard = await _context.PunchCards.SingleOrDefaultAsync(x => x.UserId == userId && x.Id == id);

            return punchCard;
        }

        public async Task<List<PunchCard>> GetPunchCardsAsync(int userId)
        {
            return await _context.PunchCards.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task CreatePunchCardAsync(PunchCard punchCard)
        {
            _context.PunchCards.Add(punchCard);
            await _context.SaveChangesAsync();
        }
    }
}