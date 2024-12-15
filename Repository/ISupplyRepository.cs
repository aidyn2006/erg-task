using ERG_Task.Models;

namespace ERG_Task.Repository.impl;

public interface ISupplyRepository
{
    Task<IEnumerable<Supply>> GetAllAsync();
    Task<Supply> GetByIdAsync(int id);
    Task AddAsync(Supply supply);
    Task UpdateAsync(Supply supply);
    Task DeleteAsync(int id);
}