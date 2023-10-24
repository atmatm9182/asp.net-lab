namespace lab3_App.Models
{
    public class MemoryContactService : IContactService
    {
        private Dictionary<int, Contact> _contacts = new();

        public int Add(Contact contact)
        {
            int id = _contacts.Count != 0 ? _contacts.Keys.Max() : 0;
            contact.Id = id + 1;
            _contacts.Add(id, contact);
            return contact.Id;
        }

        public void Delete(int id)
        {
            _contacts.Remove(id);
        }

        public Contact? FindById(int id)
        {
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
    }
}
