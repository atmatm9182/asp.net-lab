using Data.Entities;

namespace lab3_App.Models
{
    public interface IContactService
    {
        int Add(Contact contact);
        void Delete(int id);
        void Update(Contact contact);
        List<Contact> FindAll();
        Contact? FindById(int id);
        List<OrganizationEntity> FindAllOrganizations();
        PagingList<Contact> FindPage(int page, int size);
    }
}
