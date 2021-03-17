using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autospace2.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {      
        }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .HasMany(c => c.Shops)
                .WithMany(s => s.Products)
                .UsingEntity<ProductShop> (
                   j => j
                    .HasOne(pt => pt.Shop)
                    .WithMany(t => t.ProductShops)
                    .HasForeignKey(pt => pt.ShopId),
                j => j
                    .HasOne(pt => pt.Product)
                    .WithMany(p => p.ProductShops)
                    .HasForeignKey(pt => pt.ProductId),
                j =>
                {
                    j.HasKey(t => new { t.ShopId, t.ProductId });
                    j.HasData(
                        new { ShopId = 1, ProductId = 1},
                        new { ShopId = 1, ProductId = 2},
                        new { ShopId = 1, ProductId = 4},
                        new { ShopId = 2, ProductId = 1},
                        new { ShopId = 2, ProductId = 3},
                        new { ShopId = 3, ProductId = 2},
                        new { ShopId = 3, ProductId = 4}
                        );
                    j.ToTable("ProductShop");
                }
            );

            modelBuilder.Entity<Shop>().HasData(
                new Shop[]
                {
                new Shop { Id=1, Name="Shop1", Address="Address1", Schedule = "11-19"},
                new Shop { Id=2, Name="Shop2", Address="Address2", Schedule = "10-18"},
                new Shop { Id=3, Name="Shop3", Address="Address3", Schedule = "12-20"}
                });

            modelBuilder.Entity<Product>().HasData(
                new Product[]
                {
                new Product { Id=1, Name="Product1", Description = "Description1" },
                new Product { Id=2, Name="Product2", Description = "Description2" },
                new Product { Id=3, Name="Product3", Description = "Description3" },
                new Product { Id=4, Name="Product4", Description = "Description4" }
                });
        }
    }
}
