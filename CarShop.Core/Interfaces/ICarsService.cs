using CarShop.Core.Models;

namespace CarShop.Core.Interfaces;

public interface ICarsService
{
    Task<List<Car>> GetCars();

    Task<Guid> CreateCar(Car car);

    Task<Guid> UpdateCar(Guid vin, string model, decimal price, string color);

    Task<Guid> DeleteCar(Guid vin);
}