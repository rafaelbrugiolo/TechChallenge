using FidelityCard.Domain.Entities;
using FidelityCard.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FidelityCard.Infrastructure.Database.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task<User?> GetByIdWithCompany(Guid id)
    {
        return await DbSet
            .Include(u => u.Company)
            .FirstOrDefaultAsync(u => u.Id == id);
	}
}
