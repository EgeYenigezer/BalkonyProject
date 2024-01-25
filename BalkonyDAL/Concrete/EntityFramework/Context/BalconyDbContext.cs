using BalkonyEntity.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalkonyDAL.Concrete.EntityFramework.Context
{
    public partial class BalconyDbContext:DbContext
    {
        
        public BalconyDbContext()
        {
            
        }

        public BalconyDbContext(DbContextOptions<BalconyDbContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductUnit> ProductUnits { get; set; }

        public virtual DbSet<Stock> Stocks { get; set; }

        public virtual DbSet<StockDetail> StockDetails { get; set; }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        public virtual DbSet<Unit> Units { get; set; }

        public virtual DbSet<User> Users { get; set; }

        

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer(ConnectionHelper.MyConString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.Address).HasMaxLength(511);
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

                entity.HasOne(d => d.User).WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_User");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.Cost).HasColumnType("money");
                entity.Property(e => e.Title).HasMaxLength(511);
                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

                entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Customer");

                entity.HasOne(d => d.User).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(511);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Price).HasColumnType("decimal(15, 3)");
                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductUnit>(entity =>
            {
                entity.ToTable("ProductUnit");

                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

                entity.HasOne(d => d.Product).WithMany(p => p.ProductUnits)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductUnit_Product");

                entity.HasOne(d => d.Unit).WithMany(p => p.ProductUnits)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductUnit_Unit1");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("Stock");

                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.StockTitle).HasMaxLength(255);
                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

                entity.HasOne(d => d.Product).WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stock_Product");

                entity.HasOne(d => d.User).WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stock_User");
            });

            modelBuilder.Entity<StockDetail>(entity =>
            {
                entity.ToTable("StockDetail");

                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(511);
                entity.Property(e => e.Quantity).HasColumnType("decimal(15, 3)");
                entity.Property(e => e.QuantityUnit).HasMaxLength(50);
                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

                entity.HasOne(d => d.Stock).WithMany(p => p.StockDetails)
                    .HasForeignKey(d => d.StockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StockDetail_Stock");

                entity.HasOne(d => d.Supplier).WithMany(p => p.StockDetails)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StockDetail_Supplier");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.Address).HasMaxLength(511);
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.Phone).HasMaxLength(11);
                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

                entity.HasOne(d => d.User).WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Supplier_User");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit");

                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.UnitName).HasMaxLength(50);
                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.AddedTime).HasColumnType("datetime");
                entity.Property(e => e.Address).HasMaxLength(511);
                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.Password).HasMaxLength(511);
                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
