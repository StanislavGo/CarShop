namespace CarShop.API.Contracts;

public record CarsResponse(
    Guid Vin,
    string Model,
    decimal Price,
    string Color
);