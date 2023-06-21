using FidelityCard.Domain.Entities;
using FidelityCard.Domain.Interfaces;

namespace FidelityCard.Infrastructure.Database.Repositories;

public class PromoRepository : BaseRepository<Promo>, IPromoRepository
{
    public PromoRepository(DatabaseContext context) : base(context)
    {
    }
}
