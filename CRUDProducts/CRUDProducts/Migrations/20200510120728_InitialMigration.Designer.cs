﻿// <auto-generated />
using CRUDProducts.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRUDProducts.Migrations
{
    [DbContext(typeof(ProductLibraryContext))]
    [Migration("20200510120728_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRUDProducts.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "AMD Ryzen 5, 8GB DDR4 2400 MHz, 240GB SSD, GeForce GTX 1650",
                            Price = 55000.0,
                            ProductName = "GIGATRON PRIME R16008G240S16504G"
                        },
                        new
                        {
                            Id = 2,
                            Description = "AMD Ryzen 5, 8GB DDR4 2666 MHz, 240GB SSD, AMD Radeon RX 570",
                            Price = 58000.0,
                            ProductName = "GIGATRON PRIME LIDER MASTERBOX X"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
