using FidelityCard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FidelityCard.Infrastructure.Database.Mappings;
public class PromoMapping : BaseMapping<Promo>
{
    public override string TableName => "Promo";
    protected override void EntityMap(EntityTypeBuilder<Promo> builder)
    {
        builder.Property(p => p.ProductId)
            .IsRequired()
            .HasColumnName("ProductId");

        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnName("Name");

        builder.Property(p => p.Description)
            .IsRequired()
            .HasColumnName("Description");

        builder.Property(p => p.ImageFileName)
            .HasColumnName("ImageFileName");

        builder.Property(p => p.TimesToPrize)
            .IsRequired()
            .HasColumnName("TimesToPrize");

        builder.Property(p => p.From)
            .IsRequired()
            .HasColumnName("From");

        builder.Property(p => p.To)
            .IsRequired()
            .HasColumnName("To");
    }
}