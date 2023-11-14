using Data.Entities;

namespace lab3_App.Models
{
    public class ContactMapper
    {
        public static ContactEntity ToEntity(Contact model)
        {
            return new ContactEntity()
            {
                ContactId = model.Id,
                Name = model.Name,
                Phone = model.Phone,
                Email = model.Email,
                Birth = model.Birth,
                Priority = (int)model.Priority,
            };
        }
        public static Contact FromEntity(ContactEntity entity)
        {
            return new Contact()
            {
                Id = entity.ContactId,
                Name = entity.Name,
                Phone = entity.Phone,
                Email = entity.Email,
                Birth = entity.Birth,
                Priority = (Priority)entity.Priority,
                OrganizationId = entity.OrganizationId,
            };
        }
    }
}
