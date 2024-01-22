using Data;
using Data.Entities;

namespace lab3_App.Models;

public class EFOperatingSystemService : IOperatingSystemService
{
    private AppDbContext _context;

    public EFOperatingSystemService(AppDbContext context)
    {
        _context = context;
    }

    public int Add(OperatingSystemEntity os)
    {
        _context.OperatingSystems.Add(os);
        _context.SaveChanges();
        return os.Id;
    }

    public void Delete(int id)
    { 
        var os = _context.OperatingSystems.Find(id);
        if (os is null)
        {
            return;
        }
        _context.OperatingSystems.Remove(os);
        _context.SaveChanges();
    }

    public List<OperatingSystemEntity> FindAll()
        => _context.OperatingSystems.ToList();

    public OperatingSystemEntity? FindById(int id)
        => _context.OperatingSystems.Find(id);

    public void Update(OperatingSystemEntity os)
    {
        _context.OperatingSystems.Update(os);
        _context.SaveChanges();
    }
}