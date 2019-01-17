using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PunchCardApp.Data;
using PunchCardApp.Models;
using PunchCardApp.Utils;

namespace PunchCardApp.Services
{
    public class UserService : IUserService
    {
        private readonly PunchCardAppContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(PunchCardAppContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            return user;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            if (_context.Users.FirstOrDefault(x => x.Email == user.Email) != null) return null;
            user.Password = _passwordHasher.HashPassword(user.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}