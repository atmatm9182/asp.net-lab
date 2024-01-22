using Data.Entities;

namespace lab3_App.Models;

public interface ISoftwareConfigurationService
{
    int Add(SoftwareConfiguration computer);
    void Delete(int id);
    void Update(SoftwareConfiguration computer);
    List<SoftwareConfiguration> FindAll();
    SoftwareConfiguration? FindById(int id);
    List<SoftwareApplicationEntity> GetApplications(int id);
}