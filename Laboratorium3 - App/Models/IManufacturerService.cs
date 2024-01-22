using Data.Entities;

namespace lab3_App.Models;

public interface IManufacturerService
{
    int Add(Manufacturer manufacturer);
    void Delete(int id);
    void Update(Manufacturer manufacturer);
    List<Manufacturer> FindAll();
    Manufacturer? FindById(int id);
}