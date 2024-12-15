using ERG_Task.Models;

namespace ERG_Task.Repository;

public interface IEventHistoryRepository
{
    Task<IEnumerable<EventHistory>> GetAllAsync();
    Task<EventHistory> GetByIdAsync(int id);
    Task AddAsync(EventHistory eventHistory);
    Task UpdateAsync(EventHistory eventHistory);
    Task DeleteAsync(int id);
}