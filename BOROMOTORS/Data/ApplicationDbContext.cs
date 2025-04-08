using BOROMOTORS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BOROMOTORS.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<DirtBike> DirtBikes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Motor> Motors { get; set; }  // Увери се, че имаш този модел

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Конфигурация на Order -> DirtBike връзка
            modelBuilder.Entity<Order>()
                .HasOne(o => o.DirtBike)
                .WithMany()
                .HasForeignKey(o => o.DirtBikeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Order -> Customer връзка
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Уникални индекси
            modelBuilder.Entity<DirtBike>()
                .HasIndex(d => d.Model)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();
        }
    }
}
