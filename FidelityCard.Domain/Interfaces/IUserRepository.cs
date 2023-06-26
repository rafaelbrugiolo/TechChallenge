using FidelityCard.Domain.Entities;

namespace FidelityCard.Domain.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
	Task<User?> GetByIdWithCompany(Guid id);
}
