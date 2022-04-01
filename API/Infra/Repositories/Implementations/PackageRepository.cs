using API.Model;
using Microsoft.EntityFrameworkCore;

using API.Infra.Context;
using API.Infra.Repositories.Interfaces;


namespace API.Infra.Repositories.Implementations;

public class PackageRepository : IPackageRepository
{
    private readonly DatabaseContext _databaseContext;
    private DbSet<Package> entity;

    public PackageRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        entity = _databaseContext.Set<Package>();
    }

    public Package? FindByID(Guid id)
    {
        var package = entity.SingleOrDefault(p => p.id == id);
        return package;
    }

    public IEnumerable<Package> List()
    {
        var packages = entity.ToList();
        return packages;
    }

    public void Create(Package package)
    {
        entity.Add(package);
    }

    public void Update(Package package)
    {
        entity.Update(package);
    }

    public void Delete(Package package)
    {
        entity.Remove(package);
    }

    public void SaveChanges()
    {
        _databaseContext.SaveChanges();
    }

}