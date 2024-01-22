using Data.Entities;

namespace lab3_App.Models;

public class SoftwareConfigurationMapper
{
    public static SoftwareConfiguration FromEntity(SoftwareConfigurationEntity entity)
    {
        return new SoftwareConfiguration()
        {
            Id = entity.Id,
            ApplicationIds = entity.InstalledApplications.Select(a => a.Id).ToList(),
            OperatingSystem = entity.OperatingSystem,
        };
    }

    public static SoftwareConfigurationEntity ToEntity(SoftwareConfiguration softwareConfiguration)
    {
        return new SoftwareConfigurationEntity()
        {
            Id = softwareConfiguration.Id,
            OperatingSystem = softwareConfiguration.OperatingSystem,
        };
    }
}