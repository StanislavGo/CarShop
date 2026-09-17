namespace CarShop.Core.Models;

public class Car
{
    public const int MAX_MODEL_LENGTH = 200;
    
    public Car(Guid vin, string model, decimal price, string color)
    {
        Vin = vin;
        Model = model;
        Price = price;
        Color = color;
    }
    
    public Guid Vin { get; set; }

    public string Model { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Color { get; set; } = string.Empty;

    public static (Car car, string error) Create(Guid vin, string model, decimal price, string color)
    {
        var error = string.Empty;

        if (string.IsNullOrEmpty(model) || model.Length > MAX_MODEL_LENGTH)
        {
            error = "Model cannot be null or over than 200 characters";
        }

        var car = new Car(vin, model, price, color);
        return (car, error);
    }
}