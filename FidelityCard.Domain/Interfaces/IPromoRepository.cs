using FidelityCard.Domain.Entities;

namespace FidelityCard.Domain.Interfaces;

public interface IPromoRepository : IBaseRepository<Promo>
{
	Task<Promo?> GetByIdWithCompanyUserProduct(Guid id);
}
