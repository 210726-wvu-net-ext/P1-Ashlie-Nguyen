using Microsoft.EntityFrameworkCore;

namespace P1.Data.Models
{
    public class P1Context : DbContext
    {
        public P1Context(DbContextOptions<P1Context> options)
            : base(options)
        {
        }

        // dbsets for my tables
        // (if there's some dbset you won't use directly, you can leave it out here)
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductOrder> ProductOrder { get; set; }

        // onmodelcreating override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add any non-default configuration of the model

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id)
                    .IsRequired();

                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.FirstName)
                    .IsRequired();

                entity.Property(e => e.LastName)
                    .IsRequired();
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id)
                    .IsRequired();

                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("decimal(5,2)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id)
                    .IsRequired();

                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(5,2)");
            });

            modelBuilder.Entity<ProductOrder>(entity =>
            {
                entity.ToTable("ProductOrder");

                entity.Property(e => e.Id)
                    .IsRequired();

                entity.HasIndex(e => e.Id)
                    .IsUnique();
            });

            // db-first scaffold creates fluent API for relationships, just for clarity
            // (entity.HasOne().HasMany() etc), but it doesn't actually need to
            // since conventions will suffice for the defaults.
            // if you want to set up, e.g., on-delete-cascade, you'll need to
            // configure it with fluent API (or data annotations), though.

            // with code-first, you can specify initial data ("seed data") for the tables as well, right here
            // https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding

            modelBuilder.Entity<Location>()
                .HasData(new Location[]
                {
                    new Location { Id = 1, Store = "Best Buy - Pentagon city", StreetAddress = "#1 Pentagon City", State = "VA", Hours = "7am-midnight", OpeningDate = new System.DateTime(2021, 1, 1), ZipCode = "22206" },
                    new Location { Id = 2, Store = "Best Buy - Potomac Yards", StreetAddress = "#1 Potomac Yards", State = "VA", Hours = "7am-midnight", OpeningDate = new System.DateTime(2021, 1, 1), ZipCode = "22206" }
                });
        }
    }
}
