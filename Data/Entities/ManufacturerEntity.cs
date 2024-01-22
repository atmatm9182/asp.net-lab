using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Models;

namespace Data.Entities;

[Table("manufacturers")]
public class ManufacturerEntity
{
     public int Id { get; set; }
     [Required]
     [MaxLength(50)]
     public string Name { get; set; }
     public string? Description { get; set; }
     public string? WebsiteUrl { get; set; }
     public Address? Address { get; set; }
}