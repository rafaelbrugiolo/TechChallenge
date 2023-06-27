using FidelityCard.Domain.Entities;
using FidelityCard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FidelityCard.Infrastructure.Database.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(DatabaseContext context) : base(context)
    {
	}
}
