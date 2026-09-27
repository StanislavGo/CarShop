using CarShop.DataAccess.Configuration;
using CarShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarShop.DataAccess;

public class CarShopDbContext(DbContextOptions<CarShopDbContext> options) 
    : DbContext(options)
{

    public DbSet<CarEntity> Cars => Set<CarEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CarConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}