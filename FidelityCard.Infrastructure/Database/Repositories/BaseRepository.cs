using Microsoft.EntityFrameworkCore;
using FidelityCard.Domain.Entities;
using FidelityCard.Domain.Interfaces;

namespace FidelityCard.Infrastructure.Database.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly DatabaseContext Context;
    protected readonly DbSet<TEntity> DbSet;

    protected BaseRepository(DatabaseContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    public void Insert(TEntity entity)
    {
        DbSet.Add(entity);
    }

    public TEntity? Read(Guid id)
    {
        return DbSet.Find(id);
    }

    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public void Delete(Guid id)
    {
        var entity = DbSet.Find(id);
        if (entity is not null)
            DbSet.Remove(entity);
    }

    public IEnumerable<TEntity> List()
    {
        return DbSet.AsNoTracking().AsQueryable();
    }

    public int SaveChanges()
    {
        return Context.SaveChanges();
    }

    public void Dispose()
    {
        Context?.Dispose();
    }
}