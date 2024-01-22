using Data;
using Data.Entities;

namespace lab3_App.Models
{
    public class EFComputerService : IComputerService
    {
        private readonly AppDbContext _context;

        public EFComputerService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Computer computer)
        {
            var entity = ComputerMapper.ToEntity(computer);
            _context.Computers.Add(entity);
            _context.SaveChanges();
            return entity.ComputerId;
        }

        public void Delete(int id)
        {
            var computer = _context.Computers.Find(id);
            if (computer is not null)
            {
                _context.Computers.Remove(computer);
                _context.SaveChanges();
            }
        }

        public void Update(Computer computer)
        {
            _context.Computers.Update(ComputerMapper.ToEntity(computer));
            _context.SaveChanges();
        }

        public List<Computer> FindAll()
            => _context.Computers.Select(ComputerMapper.FromEntity).ToList();

        public Computer? FindById(int id)
        {
            var entity = _context.Computers.Find(id);
            if (entity is not null)
            {
                return ComputerMapper.FromEntity(entity);
            }

            return null;
        }

        public List<ManufacturerEntity> FindAllManufacturers()
        {
            throw new NotImplementedException();
        }
    }
}
