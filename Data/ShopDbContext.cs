
using Microsoft.EntityFrameworkCore;
using MyToyAPI.Entities;

namespace MyToyAPI.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
        }

        // ===== DbSets =====
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Cart> Cart { get; set; } = null!;

        // ===== Fluent API =====
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                // Table
                entity.ToTable("Users");

                // Primary Key
                entity.HasKey(u => u.Id);

                // Properties
                entity.Property(u => u.FirstName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(u => u.LastName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(u => u.Email)
                      .IsRequired()
                      .HasMaxLength(256);

                entity.Property(u => u.PasswordHash)
                      .IsRequired()
                      .HasMaxLength(512);

                entity.Property(u => u.IsActive)
                      .HasDefaultValue(true);

                entity.Property(u => u.CreatedAt)
                      .HasDefaultValueSql("GETUTCDATE()");

                // Indexes
                entity.HasIndex(u => u.Email)
                      .IsUnique()
                      .HasDatabaseName("UX_Users_Email");
            });
        }
    }
}
