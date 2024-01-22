using Data;
using Data.Entities;

namespace lab3_App.Models;

public class EFSoftwareConfigurationService : ISoftwareConfigurationService
{
  private readonly AppDbContext _context;
  
          public EFSoftwareConfigurationService(AppDbContext context)
          {
              _context = context;
          }
  
          public int Add(SoftwareConfiguration computer)
          {
              var entity = SoftwareConfigurationMapper.ToEntity(computer);
              _context.SoftwareConfigurations.Add(entity);
              _context.SaveChanges();
              return entity.Id;
          }
  
          public void Delete(int id)
          {
              var computer = _context.SoftwareConfigurations.Find(id);
              if (computer is not null)
              {
                  _context.SoftwareConfigurations.Remove(computer);
                  _context.SaveChanges();
              }
          }
  
          public void Update(SoftwareConfiguration computer)
          {
              _context.SoftwareConfigurations.Update(SoftwareConfigurationMapper.ToEntity(computer));
              _context.SaveChanges();
          }
  
          public List<SoftwareConfiguration> FindAll()
              => _context.SoftwareConfigurations.Select(SoftwareConfigurationMapper.FromEntity).ToList();
  
          public SoftwareConfiguration? FindById(int id)
          {
              var entity = _context.SoftwareConfigurations.Find(id);
              if (entity is not null)
              {
                  return SoftwareConfigurationMapper.FromEntity(entity);
              }
  
              return null;
          }

          public List<SoftwareApplicationEntity> GetApplications(int id)
          {
              var conf = _context.SoftwareConfigurations.Find(id);
              if (conf is null)
              {
                  return new List<SoftwareApplicationEntity>();
              }

              return conf.InstalledApplications.ToList();
          }
}