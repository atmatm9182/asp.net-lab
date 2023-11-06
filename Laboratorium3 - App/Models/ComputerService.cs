namespace lab3_App.Models;

public interface IComputerService
{
    int Add(Computer computer);
    void Delete(int id);
    void Update(Computer computer);
    List<Computer> FindAll();
    Computer? FindById(int id);
}