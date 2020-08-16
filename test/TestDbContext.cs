using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RosabellaCosmetics.Domain.Entities;

namespace test
{
    public class TestDbContext:DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        //public DbSet<Gender> Genders { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderDetails> OrderDetails { get; set; }
        //public DbSet<Stock> Stocks { get; set; }
        //
        //public DbSet<Supplier> Suppliers { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //    #region Product

        //    modelBuilder.Entity<Product>()
        //        .Property(x => x.Name)
        //        .HasMaxLength(50)
        //        .HasColumnType("nvarchar");

        //    modelBuilder.Entity<Product>()
        //        .Property(x => x.Price)
        //        .IsRequired()
        //        .HasDefaultValue(0);

        //    modelBuilder.Entity<Product>()
        //        .Property(x => x.QuantityInStock)
        //        .HasDefaultValue(0);

        //    #endregion

        //    #region Customer

        //    modelBuilder.Entity<Customer>()
        //        .Property(x => x.FirstName)
        //        .HasMaxLength(50)
        //        .HasColumnType("nvarchar")
        //        .IsRequired();

        //    modelBuilder.Entity<Customer>()
        //        .Property(x => x.LastName)
        //        .HasMaxLength(50)
        //        .HasColumnType("nvarchar")
        //        .IsRequired();

        //    modelBuilder.Entity<Customer>()
        //        .Property(x => x.Email)
        //        .HasMaxLength(62)
        //        .HasColumnType("varchar")
        //        .IsRequired();

        //    modelBuilder.Entity<Customer>()
        //        .Property(x => x.Country)
        //        .IsRequired();

        //    modelBuilder.Entity<Customer>()
        //        .Property(x => x.City)
        //        .IsRequired();

        //    modelBuilder.Entity<Customer>()
        //        .Property(x => x.PasswordHash)
        //        .HasMaxLength(128)
        //        .HasColumnType("nvarchar")
        //        .IsRequired();

        //    modelBuilder.Entity<Customer>()
        //        .Property(x => x.PasswordSalt)
        //        .HasMaxLength(128)
        //        .HasColumnType("nvarchar")
        //        .IsRequired();

        //    #endregion
        //}
    }
}
