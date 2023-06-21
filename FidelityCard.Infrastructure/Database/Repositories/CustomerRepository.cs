using FidelityCard.Domain.Entities;
using FidelityCard.Domain.Interfaces;

namespace FidelityCard.Infrastructure.Database.Repositories;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(DatabaseContext context) : base(context)
    {
    }
}
