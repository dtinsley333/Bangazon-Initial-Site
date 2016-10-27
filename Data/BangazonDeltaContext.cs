using Microsoft.EntityFrameworkCore;
using BangazonDelta.Models;

namespace BangazonDelta.Data
{
    public class BangazonDeltaContext : DbContext
    {
        public BangazonDeltaContext(DbContextOptions<BangazonDeltaContext> options)
            : base(options)
        { }

        // What tables are you interacting with in this context class?
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<ProductSubType> ProductSubType { get; set; }

        // Set up your default timestamp formats for each class using a timestamp
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Customer>()
        //         .Property(b => b.DateCreated)
        //         .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

        //     modelBuilder.Entity<Order>()
        //         .Property(b => b.DateCreated)
        //         .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

        //     modelBuilder.Entity<PaymentType>()
        //         .Property(b => b.DateCreated)
        //         .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

        //     modelBuilder.Entity<Product>()
        //         .Property(b => b.DateCreated)
        //         .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");
        // }
    }

}