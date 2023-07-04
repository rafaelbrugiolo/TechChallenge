using System.Collections.Generic;
using FidelityCard.Domain.Entities;

namespace FidelityCard.Domain.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    void Insert(TEntity entity);
    TEntity? Read(Guid id);
    void Update(TEntity entity);
    void Delete(Guid id);
    IEnumerable<TEntity> List();
    int SaveChanges();
    void Dispose();
}
