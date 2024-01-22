using System.ComponentModel.DataAnnotations.Schema;
using Data.Models;

namespace Data.Entities;

[Table("software_configurations")]
public class SoftwareConfigurationEntity
{
    public int Id { get; set; }
    
    public string? OperatingSystem { get; set; }

    public List<SoftwareApplicationEntity> InstalledApplications { get; set; }
    
    public List<ComputerEntity> Computers { get; set; }
}