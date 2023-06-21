using Microsoft.EntityFrameworkCore;
using FidelityCard.Domain.Entities;
using FidelityCard.Infrastructure.Database.Mappings;

namespace FidelityCard.Infrastructure.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<Company> Company { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Promo> Promo { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			relationship.DeleteBehavior = DeleteBehavior.NoAction;

		new CompanyMapping().Initialize(modelBuilder.Entity<Company>());
        new UserMapping().Initialize(modelBuilder.Entity<User>());
        new CustomerMapping().Initialize(modelBuilder.Entity<Customer>());
        new ProductMapping().Initialize(modelBuilder.Entity<Product>());
        new PromoMapping().Initialize(modelBuilder.Entity<Promo>());

		base.OnModelCreating(modelBuilder);
	}
}
