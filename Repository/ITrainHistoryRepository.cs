using ERG_Task.Models;

namespace ERG_Task.Repository;

public interface ITrainHistoryRepository
{
    Task<IEnumerable<TrainHistory>> GetAllAsync();
    Task<TrainHistory> GetByIdAsync(int id);
    Task AddAsync(TrainHistory trainHistory);
    Task UpdateAsync(TrainHistory trainHistory);
    Task DeleteAsync(int id);
}