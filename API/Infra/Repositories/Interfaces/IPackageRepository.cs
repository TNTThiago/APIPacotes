using API.Model;

namespace API.Infra.Repositories.Interfaces;

public interface IPackageRepository
{
    Package? FindByID(Guid id);
    IEnumerable<Package> List();
    void Create(Package package);
    void Update(Package package);
    void Delete(Package package);
    void SaveChanges();
}