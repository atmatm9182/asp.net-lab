using Data;
using Data.Entities;

namespace lab3_App.Models
{
    public class EFContactService : IContactService
    {
        private readonly AppDbContext _context;

        public EFContactService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Contact contact)
        {
            var e = _context.Contacts.Add(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
            return e.Entity.ContactId;
        }

        public void Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            if(contact != null) 
            {
                _context.Contacts.Remove(contact);

                _context.SaveChanges();
            }
        }

        public List<Contact> FindAll()
        {
            return _context.Contacts.Select(e => ContactMapper.FromEntity(e)).ToList();
        }

        public List<OrganizationEntity> FindAllOrganizations()
        {
            return _context.Organizations.ToList();
        }

        public Contact? FindById(int id)
        {
            var e = _context.Contacts.Find(id);
            if(e != null)
            {
                return ContactMapper.FromEntity(e);
            }
            return null;
        }

        public PagingList<Contact> FindPage(int page, int size)
        {
            var p = PagingList<Contact>.Create(null, _context.Contacts.Count(), page, size);
            var data = _context.Contacts.OrderBy(o => o.Name).Skip((p.Number - 1) * p.Size).Take(p.Size).Select(ContactMapper.FromEntity);
            return PagingList<Contact>.Create(data.ToList(), _context.Contacts.Count(), page, size);

        }

        public void Update(Contact contact)
        {
            _context.Contacts.Update(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
        }
    }
}
