using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.Domain.Entities;
using TechChallenge.Infrastructure.Database.Common;

namespace TechChallenge.Infrastructure.Database.Mappings;

public abstract class BaseMapping<T> : IBaseMapping where T : BaseEntity
{
    public abstract string TableName { get; }

    public void Initialize(EntityTypeBuilder<T> builder)
    {
        BaseMap(builder);
        PrimaryKeyMap(builder);
        EntityMap(builder);
    }

    protected abstract void EntityMap(EntityTypeBuilder<T> entityTypeBuilder);

    private void BaseMap(EntityTypeBuilder<T> builder)
    {
        builder.ToTable(TableName);
        builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
    }

    protected virtual void PrimaryKeyMap(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
    