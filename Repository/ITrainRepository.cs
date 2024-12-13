using ERG_Task.Models;

namespace ERG_Task.Repository;

public interface ITrainRepository
{
    Task<IEnumerable<Train>> GetAllAsync();
    Task<Train> GetByIdAsync(int id);
    Task AddAsync(Train train);
    Task UpdateAsync(Train train);
    Task DeleteAsync(int id);
}