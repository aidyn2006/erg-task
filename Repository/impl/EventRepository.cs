using ERG_Task.Data;
using ERG_Task.Models;

namespace ERG_Task.Repository.impl;

public class EventRepository : IEventRepository
{
    private readonly AppDbContext _context;

    public EventRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<Event>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Event> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Train train)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Train train)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}