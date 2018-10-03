namespace MM.Database
{
    using Microsoft.EntityFrameworkCore;
    using Core.Contracts.Entities;
    using Orders.Contracts.Entities;

    public class MMDbContext : DbContext
    {
        public MMDbContext(DbContextOptions<MMDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product #1" }, 
                new Product { Id = 2, Name = "Product #2" },
                new Product { Id = 3, Name = "Product #3" },
                new Product { Id = 4, Name = "Product #4" });

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Customer #1" },
                new Customer { Id = 2, Name = "Customer #2" },
                new Customer { Id = 3, Name = "Customer #3" },
                new Customer { Id = 4, Name = "Customer #4" });
        }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }
    }
}