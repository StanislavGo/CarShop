using CarShop.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShop.DataAccess;

public class CarShopDbContext : DbContext
{
    public CarShopDbContext(DbContextOptions<CarShopDbContext> options) : base(options)
    {
    }

    public DbSet<Car> Cars;
}