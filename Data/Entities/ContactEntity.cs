using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("contacts")]
    public class ContactEntity
    {
        [Key]
        [Column("id")]
        public int ContactId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? Birth { get; set; }
        public int Priority { get; set; }
        public OrganizationEntity? Organization { get; set; }
        public int? OrganizationId { get; set; }
    }
}
