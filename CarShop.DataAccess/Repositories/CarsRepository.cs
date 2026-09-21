using CarShop.Core.Interfaces;
using CarShop.Core.Models;
using CarShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarShop.DataAccess.Repositories;

public class CarsRepository : ICarsRepository
{
    private CarShopDbContext _dbContext;

    public CarsRepository(CarShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Car>> Get()
    {
        var carEntities = await _dbContext.Cars
            .AsNoTracking()
            .ToListAsync();

        var cars = carEntities
            .Select(c => Car.Create(c.Vin, c.Model, c.Price, c.Color).car)
            .ToList();

        return cars;
    }

    public async Task<Guid> Create(Car car)
    {
        var carEntity = new CarEntity
        {
            Vin = car.Vin,
            Color = car.Color,
            Model = car.Model,
            Price = car.Price
        };

        await _dbContext.Cars.AddAsync(carEntity);
        await _dbContext.SaveChangesAsync();

        return carEntity.Vin;
    }

    public async Task<Guid> Update(Guid vin, string model, decimal price, string color)
    {
        var affectedRows = await _dbContext.Cars
            .Where(c => c.Vin == vin)
            .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Color, c => color)
                .SetProperty(c => c.Model, c => model)
                .SetProperty(c => c.Price, c => price));

        if (affectedRows == 0)
            throw new KeyNotFoundException($"Car with Vin {vin} not found.");

        return vin;
    }

    public async Task<Guid> Delete(Guid vin)
    {
        await _dbContext.Cars
            .Where(c => c.Vin == vin)
            .ExecuteDeleteAsync();

        return vin;
    }
}