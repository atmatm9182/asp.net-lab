using Data.Entities;

namespace lab3_App.Models;

public static class ComputerMapper
{
    public static Computer FromEntity(ComputerEntity computerEntity)
    {
        return new Computer
        {
            Id = computerEntity.ComputerId,
            Name = computerEntity.Name,
            Created = computerEntity.Created,
            CPU = computerEntity.CPU,
            Manufacturer = computerEntity.Manufacturer,
            ProductionDate = computerEntity.ProductionDate,
            GPU = computerEntity.GPU,
            RAM = computerEntity.RAM,
        };
    }

    public static ComputerEntity ToEntity(Computer computer)
    {
        return new ComputerEntity
        {
            ComputerId = computer.Id,
            Created = computer.Created,
            CPU = computer.CPU,
            Manufacturer = computer.Manufacturer,
            ProductionDate = computer.ProductionDate,
            GPU = computer.GPU,
            RAM = computer.RAM,
            Name = computer.Name,
        };
    }
}