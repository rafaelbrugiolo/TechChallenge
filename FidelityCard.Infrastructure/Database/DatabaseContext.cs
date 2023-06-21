using Microsoft.EntityFrameworkCore;
using FidelityCard.Domain.Entities;
using FidelityCard.Infrastructure.Database.Mappings;

namespace FidelityCard.Infrastructure.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new CompanyMapping().Initialize(modelBuilder.Entity<Company>());
        new UserMapping().Initialize(modelBuilder.Entity<User>());
        new CustomerMapping().Initialize(modelBuilder.Entity<Customer>());
        new ProductMapping().Initialize(modelBuilder.Entity<Product>());
        new PromoMapping().Initialize(modelBuilder.Entity<Promo>());
    }
}
