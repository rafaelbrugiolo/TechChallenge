﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using FidelityCard.Infrastructure.Database;

#nullable disable

namespace FidelityCard.Infrastructure.Migrations;

[DbContext(typeof(DatabaseContext))]
[Migration("20230531153655_Initial")]
partial class Initial
{
    /// <inheritdoc />
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "7.0.5")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        modelBuilder.Entity("FidelityCard.Domain.Entities.User", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier")
                    .HasColumnName("Id");

                b.Property<string>("AvatarFileName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)")
                    .HasColumnName("AvatarFileName");

                b.Property<DateTime>("Birthdate")
                    .HasColumnType("datetime2")
                    .HasColumnName("Birthdate");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)")
                    .HasColumnName("Name");

                b.HasKey("Id");

                b.ToTable("User", (string)null);
            });
#pragma warning restore 612, 618
    }
}