using System.Collections.Generic;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces;

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
