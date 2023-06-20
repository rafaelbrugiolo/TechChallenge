using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FidelityCard.Domain.Entities;

namespace FidelityCard.Infrastructure.Database.Mappings;
public class CompanyMapping : BaseMapping<Company>
{
    public override string TableName => "Company";
    protected override void EntityMap(EntityTypeBuilder<Company> entityTypeBuilder)
	{
		entityTypeBuilder.Property(p => p.Cnpj)
			.IsRequired()
			.HasColumnName("Cnpj");

		entityTypeBuilder.Property(p => p.TradeName)
			.IsRequired()
			.HasColumnName("TradeName");

		entityTypeBuilder.Property(p => p.TradeName)
			.IsRequired()
			.HasColumnName("TradeName");

		entityTypeBuilder.Property(p => p.IsRemoved)
			.IsRequired()
			.HasColumnName("IsRemoved");
    }
}