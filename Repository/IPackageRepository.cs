using ERG_Task.Models;

namespace ERG_Task.Repository;

public interface IPackageRepository
{
    Task<IEnumerable<Package>> GetAllAsync(int? type,int? status);
    Task<Package> GetByIdAsync(int id);
    Task AddAsync(Package package);
    Task UpdateAsync(Package package);
    Task DeleteAsync(int id);
}