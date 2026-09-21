using CarShop.BusinessLogic.Services;
using CarShop.Core.Interfaces;
using CarShop.Core.Models;
using Moq;
using AutoFixture;

namespace CarShop.UnitTests;

public class CarsServiceTests
{
    private Mock<ICarsRepository> _carsRepositoryMock;

    private ICarsService _carsService;
    
    [SetUp]
    public void Setup()
    {
        _carsRepositoryMock = new Mock<ICarsRepository>();
        _carsService = new CarsService(_carsRepositoryMock.Object);
    }

    [Test]
    public async Task GetCars_ShouldReturnCars()
    {
        var expectedCars = new List<Car>
        {
            new Car(Guid.NewGuid(), "BMW", 30000, "Black"),
            new Car(Guid.NewGuid(), "Audi", 25000, "White")
        };

        _carsRepositoryMock
            .Setup(x => x.Get())
            .ReturnsAsync(expectedCars);

        var cars = await _carsService.GetCars();

        Assert.That(cars, Is.EqualTo(expectedCars));
        
        _carsRepositoryMock.Verify(
            x => x.Get(), 
            Times.Once);
    }

    [Test]
    public async Task CreateCar_WithCorrectData_ReturnsVin()
    {
        var fixture = new Fixture();
        var car = fixture.Create<Car>();
        
        var expectedVin = car.Vin;

        _carsRepositoryMock
            .Setup(x => x.Create(car))
            .ReturnsAsync(expectedVin);
        
        var result = await _carsService.CreateCar(car);
        
        Assert.That(result, Is.EqualTo(expectedVin));
        
        _carsRepositoryMock.Verify(
            x => x.Create(car),
            Times.Once);
    }

    [Test]
    public async Task UpdateCar_WithCorrectData_ReturnsVin()
    {
        var fixture = new Fixture();
        var car = fixture.Create<Car>();

        var expectedVin = car.Vin;

        _carsRepositoryMock
            .Setup(x => x.Update(car.Vin, car.Model, car.Price, car.Color))
            .ReturnsAsync(expectedVin);

        var result = await _carsService.UpdateCar(car.Vin, car.Model, car.Price, car.Color);
        
        Assert.That(result, Is.EqualTo(expectedVin));
        
        _carsRepositoryMock.Verify(
            x => x.Update(car.Vin, car.Model, car.Price, car.Color),
            Times.Once);
    }

    [Test]
    public async Task DeleteCar_ReturnsVin()
    {
        var fixture = new Fixture();
        var car = fixture.Create<Car>();

        var expectedVin = car.Vin;
        
        await _carsService.DeleteCar(expectedVin);

        _carsRepositoryMock.Setup(x => x
            .Delete(expectedVin))
            .ReturnsAsync(expectedVin);
        
        _carsRepositoryMock.Verify(
            x => x.Delete(expectedVin),
            Times.Once);
    }
}