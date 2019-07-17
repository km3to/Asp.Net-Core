using Fdmc.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Fdmc.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; }
    }
}
