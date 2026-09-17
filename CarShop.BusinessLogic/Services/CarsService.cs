using CarShop.Core.Interfaces;
using CarShop.Core.Models;

namespace CarShop.BusinessLogic.Services;

public class CarsService : ICarsService
{
    private ICarsRepository _carsRepository;
    
    public CarsService(ICarsRepository carsRepository)
    {
        _carsRepository = carsRepository;
    }
    
    public async Task<List<Car>> GetCars()
    {
        return await _carsRepository.Get();
    }

    public async Task<Guid> CreateCar(Car car)
    {
        return await _carsRepository.Create(car);
    }

    public async Task<Guid> UpdateCar(Guid vin, string model, decimal price, string color)
    {
        return await _carsRepository.Update(vin, model, price, color);
    }

    public async Task<Guid> DeleteCar(Guid vin)
    {
        return await _carsRepository.Delete(vin);
    }
}