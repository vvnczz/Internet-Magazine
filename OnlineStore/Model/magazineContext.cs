using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineStore.Model
{
    public partial class magazineContext : DbContext
    {
        public magazineContext()
        {
        }

        public magazineContext(DbContextOptions<magazineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<Supply> Supplies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAB4-13;Database=magazine;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.Email).HasMaxLength(70);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Number).HasMaxLength(14);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Number).HasMaxLength(14);

                entity.Property(e => e.Post).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Orders_Employee");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Orders_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Number).HasMaxLength(50);
            });

            modelBuilder.Entity<Supply>(entity =>
            {
                entity.ToTable("Supply");

                entity.Property(e => e.DateSupply).HasColumnType("date");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Supply_Product");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Supply_Supplier");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
