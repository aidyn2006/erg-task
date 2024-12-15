using ERG_Task.Data;
using ERG_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace ERG_Task.Repository.impl;

public class EventRepository : IEventRepository
{
    private readonly AppDbContext _context;

    public EventRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Event>> GetAllAsync()
    {
        return await _context.Events
            .Include(g=>g.EventHistories)
            .ToListAsync();
    }

    public async Task<Event?> GetByIdAsync(int id)
    {
        return await _context.Events
            .Include(g=>g.EventHistories)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Event invoice)
    {
        await _context.Events.AddAsync(invoice);
        await _context.SaveChangesAsync();    
    }

    public async Task UpdateAsync(Event invoice)
    {
        _context.Events.Update(invoice);
        await _context.SaveChangesAsync();    }

    public async Task DeleteAsync(int id)
    {
        var invoice = await _context.Events.FindAsync(id);
        if (invoice != null)
        {
            _context.Events.Remove(invoice);
            await _context.SaveChangesAsync();
        }    
    }
}