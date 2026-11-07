using CampusLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampusLibrary.Infrastructure.Data;

public class CampusLibraryDbContext : DbContext
{
    public CampusLibraryDbContext(
        DbContextOptions<CampusLibraryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Title).IsRequired().HasMaxLength(200);
            entity.Property(b => b.Author).IsRequired().HasMaxLength(100);
            entity.Property(b => b.ISBN).IsRequired().HasMaxLength(13);
        });
    }
}
