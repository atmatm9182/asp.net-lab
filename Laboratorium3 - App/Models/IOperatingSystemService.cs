using Data.Entities;

namespace lab3_App.Models;

public interface IOperatingSystemService
{
    int Add(OperatingSystemEntity os);
    void Delete(int id);
    void Update(OperatingSystemEntity os);
    List<OperatingSystemEntity> FindAll();
    OperatingSystemEntity? FindById(int id);
}