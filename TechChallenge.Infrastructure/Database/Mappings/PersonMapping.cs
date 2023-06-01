using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infrastructure.Database.Mappings;
public class PersonMapping : BaseMapping<Person>
{
    public override string TableName => "Person";
    protected override void EntityMap(EntityTypeBuilder<Person> entityTypeBuilder)
    {
        entityTypeBuilder.Property(p => p.Name)
            .IsRequired()
            .HasColumnName("Name");

        entityTypeBuilder.Property(p => p.Birthdate)
            .IsRequired()
            .HasColumnName("Birthdate");

        entityTypeBuilder.Property(p => p.AvatarFileName)
            .HasColumnName("AvatarFileName");
    }
}