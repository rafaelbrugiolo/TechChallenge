using FidelityCard.Domain.Entities;
using FidelityCard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FidelityCard.Infrastructure.Database.Repositories;

public class PromoRepository : BaseRepository<Promo>, IPromoRepository
{
    public PromoRepository(DatabaseContext context) : base(context)
    {
	}

	public IEnumerable<Promo?> GetByAllWithProduct()
	{
		return DbSet.Include(u => u.Product);
	}

	public async Task<Promo?> GetByIdWithProduct(Guid id)
	{
		return await DbSet
			.Include(u => u.Product)
			.FirstOrDefaultAsync(u => u.Id == id);
	}
}
