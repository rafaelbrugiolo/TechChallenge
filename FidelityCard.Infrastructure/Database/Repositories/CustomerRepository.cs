using FidelityCard.Domain.Entities;
using FidelityCard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FidelityCard.Infrastructure.Database.Repositories;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(DatabaseContext context) : base(context)
    {
	}

	public async Task<Customer?> GetByIdWithCompany(Guid id)
	{
		return await DbSet
			.Include(u => u.Company)
			.FirstOrDefaultAsync(u => u.Id == id);
	}
}
