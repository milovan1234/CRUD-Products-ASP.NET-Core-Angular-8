using CRUDProducts.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDProducts.DbContexts
{
    public class ProductLibraryContext : DbContext
    {
        public ProductLibraryContext(DbContextOptions<ProductLibraryContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    ProductName = "GIGATRON PRIME R16008G240S16504G",
                    Description = "AMD Ryzen 5, 8GB DDR4 2400 MHz, 240GB SSD, GeForce GTX 1650",
                    Price = 55000.0
                },
                new Product()
                {
                    Id = 2,
                    ProductName = "GIGATRON PRIME LIDER MASTERBOX X",
                    Description = "AMD Ryzen 5, 8GB DDR4 2666 MHz, 240GB SSD, AMD Radeon RX 570",
                    Price = 58000.0
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
