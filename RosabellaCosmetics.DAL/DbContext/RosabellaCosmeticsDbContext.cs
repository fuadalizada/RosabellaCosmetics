using Microsoft.EntityFrameworkCore;
using RosabellaCosmetics.Domain.Entities;

namespace RosabellaCosmetics.Dal.DbContext
{
    public class RosabellaCosmeticsDbContext:Microsoft.EntityFrameworkCore.DbContext
    {
        public RosabellaCosmeticsDbContext(DbContextOptions<RosabellaCosmeticsDbContext> options) : base(options)
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

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Product

            modelBuilder.Entity<Product>()
                .Property(x => x.CreatedDate)
                .HasColumnType("DateTime");

            modelBuilder.Entity<Product>()
                .Property(x => x.UpdatedDate)
                .HasColumnType("DateTime");

            modelBuilder.Entity<Product>()
                .Property(x => x.DeletedDate)
                .HasColumnType("DateTime");

            modelBuilder.Entity<Product>()
                .Property(x => x.Name)
                .HasColumnType("nvarchar(50)");

            modelBuilder.Entity<Product>()
                .Property(x => x.Price)
                .IsRequired()
                .HasDefaultValue(0);

            modelBuilder.Entity<Product>()
                .Property(x => x.QuantityInStock)
                .HasDefaultValue(0);

            #endregion

            #region Customer

            modelBuilder.Entity<Customer>()
                .Property(x => x.CreatedDate)
                .HasColumnType("DateTime");

            modelBuilder.Entity<Customer>()
                .Property(x => x.UpdatedDate)
                .HasColumnType("DateTime");

            modelBuilder.Entity<Customer>()
                .Property(x => x.DeletedDate)
                .HasColumnType("DateTime");

            modelBuilder.Entity<Customer>()
                .Property(x => x.FirstName)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(x => x.LastName)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(x => x.Email)
                .HasColumnType("varchar(62)")
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(x => x.Country)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(x => x.City)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(x => x.PasswordHash)
                .HasColumnType("nvarchar(128)")
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(x => x.PasswordSalt)
                .HasColumnType("nvarchar(128)")
                .IsRequired();

            #endregion
        }
    }
}
