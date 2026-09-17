using CarShop.Core.Models;

namespace CarShop.Core.Interfaces;

public interface ICarsRepository
{
    Task<List<Car>> Get();

    Task<Guid> Create(Car car);

    Task<Guid> Update(Guid vin, string model, decimal price, string color);

    Task<Guid> Delete(Guid vin);
}