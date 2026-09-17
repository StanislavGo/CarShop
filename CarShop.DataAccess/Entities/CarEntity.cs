namespace CarShop.DataAccess.Entities;

public class CarEntity
{
    public Guid Vin { get; set; }

    public string Model { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Color { get; set; } = string.Empty;
}