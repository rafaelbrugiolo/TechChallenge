using FidelityCard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FidelityCard.Infrastructure.Database.Mappings;
public class CustomerMapping : BaseMapping<Customer>
{
    public override string TableName => "Customer";
    protected override void EntityMap(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnName("Name");

        builder.Property(p => p.Email)
            .HasColumnName("Email");

        builder.Property(p => p.Birthdate)
            .HasColumnName("Birthdate");

        builder.Property(p => p.ContactPhone)
            .HasColumnName("ContactPhone");
    }
}