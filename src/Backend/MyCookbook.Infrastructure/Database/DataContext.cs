using Microsoft.EntityFrameworkCore;
using MyCookbook.Domain.Entities;
using MyCookbook.Infrastructure.Database.Mappings;

namespace MyCookbook.Infrastructure.Database;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
    }
}
