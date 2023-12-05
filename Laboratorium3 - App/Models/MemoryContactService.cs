using Data.Entities;

namespace lab3_App.Models
{
    public class MemoryContactService : IContactService
    {
        private Dictionary<int, Contact> _contacts = new();
        private readonly IDateTimeProvider _timeProvider;

        public MemoryContactService(IDateTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public int Add(Contact contact)
        {
            int id = _contacts.Count != 0 ? _contacts.Keys.Max() : 0;
            contact.Id = id + 1;
            contact.Created = _timeProvider.GetTime();
            _contacts.Add(contact.Id, contact);
            return contact.Id;
        }

        public void Delete(int id)
        {
            _contacts.Remove(id);
        }

        public Contact? FindById(int id)
        {
            if(! _contacts.ContainsKey(id))
            {
                return null;
            }
            return _contacts[id];
        }

        public List<Contact> FindAll()
        {
            return _contacts.Values.ToList();
        }

        public void Update(Contact contact)
        {
            _contacts[contact.Id] = contact;
        }

        public List<OrganizationEntity> FindAllOrganizations()
        {
            throw new NotImplementedException();
        }

        public PagingList<Contact> FindPage(int page, int size)
        {
            throw new NotImplementedException();
        }
    }
}
