using ERG_Task.Models;

namespace ERG_Task.Repository;

public interface IPackageHistoryRepository
{
    Task<IEnumerable<PackageHistory>> GetAllAsync();
    Task<PackageHistory> GetByIdAsync(int id);
    Task AddAsync(PackageHistory packageHistory);
    Task UpdateAsync(PackageHistory packageHistory);
    Task DeleteAsync(int id);
}