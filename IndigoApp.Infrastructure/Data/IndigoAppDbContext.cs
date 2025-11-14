using IndigoApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndigoApp.Infrastructure.Data
{
    public class IndigoAppDbContext : DbContext
    {
        public DbSet<Product> Prods => Set<Product>();
        public DbSet<Sale> Sales => Set<Sale>();
        public DbSet<SaleDetail> SaleDetails => Set<SaleDetail>();
        public DbSet<User> Users => Set<User>();

        public IndigoAppDbContext(DbContextOptions<IndigoAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(p => p.Stock).IsRequired();
                entity.Property(p => p.Image).HasMaxLength(512);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.HasIndex(u => u.Username).IsUnique();
                entity.Property(u => u.Username).IsRequired().HasMaxLength(50);
                entity.Property(u => u.Password).IsRequired();
                entity.Property(u => u.RoleUser).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Total).IsRequired().HasColumnType("decimal(18,2)");
                entity.HasOne(s => s.User)
                      .WithMany(sa => sa.Sales)
                      .HasForeignKey(s => s.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<SaleDetail>(entity =>
            {
                entity.HasKey(sd => sd.Id);
                entity.Property(sd => sd.Quantity).IsRequired();
                entity.Property(sd => sd.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(sd => sd.Subtotal).IsRequired().HasColumnType("decimal(18,2)");
                entity.HasOne(sd => sd.Sale)
                      .WithMany(s => s.SaleDetails)
                      .HasForeignKey(sd => sd.SaleId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(sd => sd.Product)
                      .WithMany(p => p.SaleDetails)
                      .HasForeignKey(sd => sd.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            SeedData.Seed(modelBuilder);
        }

    }
}
