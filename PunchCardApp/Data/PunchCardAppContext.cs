using Microsoft.EntityFrameworkCore;
using PunchCardApp.Models;

namespace PunchCardApp.Data
{
    public class PunchCardAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PunchCard> PunchCards { get; set; }

        public PunchCardAppContext(DbContextOptions<PunchCardAppContext> options) : base(options) {}
    }
}