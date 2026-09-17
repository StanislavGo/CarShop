namespace CarShop.API.Contracts;

public record CarsRequest(
    string Model,
    decimal Price,
    string Color
);