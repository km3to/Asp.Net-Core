using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Panda.Data.Models;

namespace Panda.Data
{
    public class PandaDbContext : IdentityDbContext<PandaUser, PandaUserRole, string>
    {
        public PandaDbContext(DbContextOptions<PandaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<PandaUser>()
                .HasMany(u => u.Packages)
                .WithOne(p => p.Recipient)
                .HasForeignKey(p => p.RecipientId);

            builder
                .Entity<PandaUser>()
                .HasMany(u => u.Receipts)
                .WithOne(r => r.Recipient)
                .HasForeignKey(r => r.RecipientId);

            builder
                .Entity<Package>()
                .HasOne(p => p.Receipt)
                .WithOne(r => r.Package)
                .HasForeignKey<Package>(x => x.ReceiptId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Receipt>()
                .HasOne(r => r.Package)
                .WithOne(p => p.Receipt)
                .HasForeignKey<Receipt>(x => x.PackageId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
