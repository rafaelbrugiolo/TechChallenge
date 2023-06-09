﻿using FidelityCard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FidelityCard.Infrastructure.Database.Mappings;
public class ProductMapping : BaseMapping<Product>
{
    public override string TableName => "Product";
    protected override void EntityMap(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Description)
            .IsRequired()
            .HasColumnName("Description");

        builder.Property(p => p.Price)
            .IsRequired()
            .HasPrecision(18,2)
            .HasColumnType("decimal")
			.HasColumnName("Price");

        builder.Property(p => p.PictureFileName)
            .HasColumnName("PictureFileName");
    }
}