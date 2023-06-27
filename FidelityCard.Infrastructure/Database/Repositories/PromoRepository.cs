using FidelityCard.Domain.Entities;
using FidelityCard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FidelityCard.Infrastructure.Database.Repositories;

public class PromoRepository : BaseRepository<Promo>, IPromoRepository
{
    public PromoRepository(DatabaseContext context) : base(context)
    {
	}

	public async Task<Promo?> GetByIdWithCompanyUserProduct(Guid id)
	{
		return await DbSet
			.Include(u => u.Company)
			.Include(u => u.User)
			.Include(u => u.Product)
			.FirstOrDefaultAsync(u => u.Id == id);
	}
}
