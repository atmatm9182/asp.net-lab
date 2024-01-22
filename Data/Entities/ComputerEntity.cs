using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("computers")]
    public class ComputerEntity
    {
        [Key]
        [Column("id")]
        public int ComputerId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string CPU { get; set; }
        
        [Required]
        public float RAM { get; set; }
        
        public string? GPU { get; set; }
        public ManufacturerEntity? Manufacturer { get; set; }
        [ForeignKey("Manufacturer")]
        public int? ManufacturerId { get; set; }
        public OperatingSystemEntity? OperatingSystem { get; set; }
        [ForeignKey("OperatingSystem")]
        public int? OperatingSystemId { get; set; }
        public DateTime? ProductionDate { get; set; }
        public DateTime Created { get; set; }
    }
}
