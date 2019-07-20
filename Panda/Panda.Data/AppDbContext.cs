using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Panda.Data.Models;

namespace Panda.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<AppUser>()
                .HasMany(x => x.Receipts)
                .WithOne(x => x.Recipient)
                .HasForeignKey(x => x.RecipientId);

            builder
                .Entity<AppUser>()
                .HasMany(x => x.Packages)
                .WithOne(x => x.Recipient)
                .HasForeignKey(x => x.RecipientId);

            //builder
            //    .Entity<Receipt>()
            //    .HasOne(x => x.Package)
            //    .WithOne(x => x.Receipt)
            //    //.HasForeignKey<Receipt>(x => x.PackageId)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Package>()
                .HasOne(x => x.Receipt)
                .WithOne(x => x.Package)
                .HasForeignKey<Package>(x => x.ReceiptId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
