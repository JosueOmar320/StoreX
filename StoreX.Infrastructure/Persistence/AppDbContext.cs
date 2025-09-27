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

            #region ProductCategory Relationship
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            #endregion

            #region RolePermission Relationship
            modelBuilder.Entity<RolePermission>()
                .HasKey(pc => new { pc.PermissionId, pc.RoleId });

            #endregion

            #region UserRole Relationship
            modelBuilder.Entity<UserRole>()
                .HasKey(pc => new { pc.UserId, pc.RoleId });

            #endregion

            #region UserPermission Relationship
            modelBuilder.Entity<UserPermission>()
                .HasKey(pc => new { pc.PermissionId, pc.UserId });

            #endregion

            #region Product Default values
            modelBuilder.Entity<User>()
                .Property(p => p.IsActive)
                .HasDefaultValue(true)   // DEFAULT en DB
                .IsRequired();           // NOT NULL'

            modelBuilder.Entity<User>()
             .Property(p => p.CreatedAt)
             .HasDefaultValueSql("GETUTCDATE()")  // se evalúa en el servidor al insertar
             .IsRequired();

            #endregion

            #region Movement Default values
            modelBuilder.Entity<Movement>()
             .Property(p => p.CreatedAt)
             .HasDefaultValueSql("GETUTCDATE()")  // se evalúa en el servidor al insertar
             .IsRequired();           // NOT NULL'

            #endregion

            #region Inventory Default values
            modelBuilder.Entity<Inventory>()
             .Property(p => p.LastUpdate)
             .HasDefaultValueSql("GETUTCDATE()")  // se evalúa en el servidor al insertar
             .IsRequired();           // NOT NULL'

            #endregion

            #region Supplier Default values
            modelBuilder.Entity<Supplier>()
            .Property(p => p.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()")  // se evalúa en el servidor al insertar
            .IsRequired();           // NOT NULL'

            modelBuilder.Entity<Supplier>()
            .Property(p => p.IsActive)
            .HasDefaultValue(true)  // se evalúa en el servidor al insertar
            .IsRequired();           // NOT NULL'

            #endregion

            #region Customer Default values
            modelBuilder.Entity<Customer>()
                .Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")  // se evalúa en el servidor al insertar
                .IsRequired();           // NOT NULL'

            modelBuilder.Entity<Customer>()
               .Property(p => p.IsActive)
               .HasDefaultValue(true)  // se evalúa en el servidor al insertar
               .IsRequired();           // NOT NULL'

            #endregion

        }
        // Define DbSets for your entities
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Movement> Movements => Set<Movement>();
        public DbSet<MovementLine> MovementLines => Set<MovementLine>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<Inventory> Inventories => Set<Inventory>();
        public DbSet<ProductSupplier> ProductSuppliers => Set<ProductSupplier>();
        public DbSet<CashMovement> CashMovements => Set<CashMovement>();
        public DbSet<CashSession> CashSessions => Set<CashSession>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderLine> OrderLines => Set<OrderLine>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Permission> Permissions => Set<Permission>();
        public DbSet<ProductPrice> ProductPrices => Set<ProductPrice>();
        public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
        public DbSet<PurchaseOrderLine> PurchaseOrderLines => Set<PurchaseOrderLine>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
        public DbSet<UserPermission> UserPermissions => Set<UserPermission>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
    }
}
