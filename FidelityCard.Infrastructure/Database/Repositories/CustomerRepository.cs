using FidelityCard.Domain.Entities;
using FidelityCard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FidelityCard.Infrastructure.Database.Repositories;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(DatabaseContext context) : base(context)
    {
	}
}
