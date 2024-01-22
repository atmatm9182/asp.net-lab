using Data;

namespace lab3_App.Models;

public class EFManufacturerService : IManufacturerService
{
    private readonly AppDbContext _context;

    public EFManufacturerService(AppDbContext context)
    {
        _context = context;
    }

    public int Add(Manufacturer manufacturer)
    {
        var entity = ManufacturerMapper.ToEntity(manufacturer);
        _context.Manufacturers.Add(entity);
        _context.SaveChanges();
        return entity.Id;
    }

    public void Delete(int id)
    {
        var entity = _context.Manufacturers.Find(id);
        if (entity == null)
        {
            return;
        }

        _context.Manufacturers.Remove(entity);
        _context.SaveChanges();
    }

    public void Update(Manufacturer manufacturer)
    {
        var entity = ManufacturerMapper.ToEntity(manufacturer);
        _context.Manufacturers.Update(entity);
        _context.SaveChanges();
    }

    public List<Manufacturer> FindAll()
    {
        return _context.Manufacturers.Select(ManufacturerMapper.FromEntity).ToList();
    }

    public Manufacturer? FindById(int id)
    {
        var entity = _context.Manufacturers.Find(id);
        if (entity == null)
        {
            return null;
        }

        return ManufacturerMapper.FromEntity(entity);
    }
}