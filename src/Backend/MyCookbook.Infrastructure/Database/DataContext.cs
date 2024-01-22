using Microsoft.EntityFrameworkCore;
using MyCookbook.Domain.Entities;
using MyCookbook.Infrastructure.Database.Mappings;

namespace MyCookbook.Infrastructure.Database;

public class DataContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Cookbook;User ID=sa;Password=1q2w3e4r@#$; TrustServerCertificate=True");
    }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
    }
}
