using CarShop.BusinessLogic.Services;
using CarShop.Core.Interfaces;
using CarShop.DataAccess;
using CarShop.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CarShopDbContext>(x =>
{
    x.UseNpgsql(builder.Configuration.GetConnectionString(nameof(CarShopDbContext)));
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICarsRepository, CarsRepository>();
builder.Services.AddScoped<ICarsService, CarsService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbScope = scope.ServiceProvider
        .GetRequiredService<CarShopDbContext>();
    
    await dbScope.Database.MigrateAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarShop API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();