using FidelityCard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FidelityCard.Infrastructure.Database.Mappings;
public class UserMapping : BaseMapping<User>
{
    public override string TableName => "User";
    protected override void EntityMap(EntityTypeBuilder<User> builder)
	{
		builder.Property(p => p.CompanyId)
			.IsRequired()
			.HasColumnName("CompanyId");

		builder.Property(p => p.Name)
			.IsRequired()
			.HasColumnName("Name");

		builder.Property(p => p.Email)
            .IsRequired()
            .HasColumnName("Email");

		builder.Property(p => p.AvatarFileName)
            .HasColumnName("AvatarFileName");
    }
}