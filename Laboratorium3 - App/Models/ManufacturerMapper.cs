using Data.Entities;

namespace lab3_App.Models;

public static class ManufacturerMapper
{
    public static ManufacturerEntity ToEntity(Manufacturer manufacturer)
    {
        return new ManufacturerEntity()
        {
            Id = manufacturer.Id,
            Address = manufacturer.Address,
            Name = manufacturer.Name,
            Description = manufacturer.Description,
            WebsiteUrl = manufacturer.WebsiteUrl,
        };
    }

    public static Manufacturer FromEntity(ManufacturerEntity manufacturerEntity)
    {
        return new Manufacturer()
        {
            Id = manufacturerEntity.Id,
            Address = manufacturerEntity.Address,
            Name = manufacturerEntity.Name,
            Description = manufacturerEntity.Description,
            WebsiteUrl = manufacturerEntity.WebsiteUrl,
        };
    }
}