using Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("organizations")]
    public class OrganizationEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public ISet<ContactEntity> Contacts { get; set; }
    }
}
