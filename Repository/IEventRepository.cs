using ERG_Task.Models;

namespace ERG_Task.Repository;

public interface IEventRepository
{
    Task<IEnumerable<Event>> GetAllAsync();
    Task<Event> GetByIdAsync(int id);
    Task AddAsync(Train train);
    Task UpdateAsync(Train train);
    Task DeleteAsync(int id);
}