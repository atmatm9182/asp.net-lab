using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("applications")]
public class SoftwareApplicationEntity
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string Version { get; set; }
    
    public List<SoftwareConfigurationEntity> Configurations { get; set; }
}