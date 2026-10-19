using IF133.Tugas1.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace IF133.Tugas1.Api.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(120);
            entity.Property(p => p.Description).HasMaxLength(500);
        });
    }
}
