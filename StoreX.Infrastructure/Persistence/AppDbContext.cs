using Microsoft.EntityFrameworkCore;
using StoreX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<User>()
                .Property(p => p.IsActive)
                .HasDefaultValue(true)   // DEFAULT en DB
                .IsRequired();           // NOT NULL'

            modelBuilder.Entity<User>()
             .Property(p => p.CreatedAt)
             .HasDefaultValueSql("GETUTCDATE()")  // se evalúa en el servidor al insertar
             .IsRequired();

        }
        // Define DbSets for your entities
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
        public DbSet<User> Users => Set<User>();
    }
}
