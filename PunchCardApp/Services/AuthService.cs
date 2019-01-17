using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PunchCardApp.Config;
using PunchCardApp.Data;
using PunchCardApp.Models;
using PunchCardApp.Utils;

namespace PunchCardApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly PunchCardAppContext _context;
        private readonly AppSettings _appSettings;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(PunchCardAppContext context, IOptions<AppSettings> appSettings, IPasswordHasher passwordHasher)
        {
            _context = context;
            _appSettings = appSettings.Value;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Authenticate(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null || _passwordHasher.Verify(password, user.Password) == false) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.Name),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}