using ERG_Task.Models;

namespace ERG_Task.Repository;

public interface IEventRepository
{
    Task<IEnumerable<Event>> GetAllAsync();
    Task<Event> GetByIdAsync(int id);
    Task AddAsync(Event events);
    Task UpdateAsync(Event events);
    Task DeleteAsync(int id);
    Task AddEventsAsync(List<Event> events);

}