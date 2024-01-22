using Data.Entities;

namespace lab3_App.Models;

public class MemoryComputerService : IComputerService
{
    private Dictionary<int, Computer> _computers = new();
    private readonly IDateTimeProvider _timeProvider;

    public MemoryComputerService(IDateTimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public int Add(Computer computer)
    {
        int id = _computers.Count != 0 ? _computers.Keys.Max() : 0;
        computer.Id = id + 1;
        computer.Created = _timeProvider.GetTime();
        _computers.Add(computer.Id, computer);
        return computer.Id;
    }

    public void Delete(int id)
    {
        _computers.Remove(id);
    }

    public Computer? FindById(int id)
    {
        return _computers[id];
    }

    public List<Computer> FindAll()
    {
        return _computers.Values.ToList();
    }

    public void Update(Computer computer)
    {
        _computers[computer.Id] = computer;
    }

    public List<ManufacturerEntity> FindAllManufacturers()
    {
        throw new NotImplementedException();
    }
}
