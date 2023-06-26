using FidelityCard.Domain.Entities;

namespace FidelityCard.Domain.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
	Task<Product?> GetByIdWithCompany(Guid id);
}
