using FidelityCard.Domain.Entities;
using FidelityCard.Domain.Interfaces;

namespace FidelityCard.Infrastructure.Database.Repositories;

public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
{
    public CompanyRepository(DatabaseContext context) : base(context)
    {
    }
}
