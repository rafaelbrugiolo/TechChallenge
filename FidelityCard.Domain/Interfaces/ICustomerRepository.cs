using FidelityCard.Domain.Entities;

namespace FidelityCard.Domain.Interfaces;

public interface ICustomerRepository : IBaseRepository<Customer>
{
	Task<Customer?> GetByIdWithCompany(Guid id);
}
