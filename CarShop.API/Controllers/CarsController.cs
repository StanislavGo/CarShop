using CarShop.API.Contracts;
using CarShop.Core.Interfaces;
using CarShop.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.API.Controllers;

[Controller]
[Route("[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarsService _carsService;
    
    public CarsController(ICarsService carsService)
    {
        _carsService = carsService;
    }

    [HttpGet]
    public async Task<ActionResult<List<CarsResponse>>> GetCars()
    {
        var cars = await _carsService.GetCars();

        var response = cars.Select(c => new CarsResponse(c.Vin, c.Model, c.Price, c.Color));

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateCar([FromBody] CarsRequest request)
    {
        var (car, error) = Car.Create(Guid.NewGuid(), request.Model, request.Price, request.Color);

        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        await _carsService.CreateCar(car);
        
        return Ok(car.Vin);
    }

    [HttpPut("{vin}")]
    public async Task<ActionResult<Guid>> UpdateCar(Guid vin, [FromBody] CarsRequest request)
    {
        var carId = await _carsService.UpdateCar(vin, request.Model, request.Price, request.Color);
        
        return Ok(carId);
    }

    [HttpDelete("{vin}")]
    public async Task<ActionResult<Guid>> DeleteCar(Guid vin)
    {
        var carId= await _carsService.DeleteCar(vin);

        return Ok(carId);
    }
}
