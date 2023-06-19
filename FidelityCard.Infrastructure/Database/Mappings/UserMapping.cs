using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FidelityCard.Domain.Entities;

namespace FidelityCard.Infrastructure.Database.Mappings;
public class UserMapping : BaseMapping<User>
{
    public override string TableName => "User";
    protected override void EntityMap(EntityTypeBuilder<User> entityTypeBuilder)
    {
        entityTypeBuilder.Property(p => p.Name)
            .IsRequired()
            .HasColumnName("Name");

        entityTypeBuilder.Property(p => p.AvatarFileName)
            .HasColumnName("AvatarFileName");
    }
}