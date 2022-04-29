using Microsoft.EntityFrameworkCore;
using SignalR.Models;

namespace Test.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Message> Message { get; set; }
    }
}
