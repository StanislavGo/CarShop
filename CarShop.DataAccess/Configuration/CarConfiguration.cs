using Microsoft.EntityFrameworkCore;
using CarShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarShop.DataAccess.Configuration;

public class CarConfiguration : IEntityTypeConfiguration<CarEntity>
{
    public void Configure(EntityTypeBuilder<CarEntity> builder)
    {
        builder.HasKey(c => c.Vin);

        builder.Property(c => c.Vin).ValueGeneratedOnAdd();
        builder.Property(c => c.Color).IsRequired();
        builder.Property(c => c.Model).IsRequired().HasMaxLength(200);
        builder.Property(c => c.Price).IsRequired();
    }
}