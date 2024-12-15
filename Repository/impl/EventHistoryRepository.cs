using ERG_Task.Data;
using ERG_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace ERG_Task.Repository.impl;

public class EventHistoryRepository : IEventHistoryRepository
{
    private readonly AppDbContext _context;

    public EventHistoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EventHistory>> GetAllAsync()
    {
        return await _context.EventHistories
            .ToListAsync();
    }

    public async Task<EventHistory?> GetByIdAsync(int id)
    {
        return await _context.EventHistories
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(EventHistory invoice)
    {
        await _context.EventHistories.AddAsync(invoice);
        await _context.SaveChangesAsync();    
    }

    public async Task UpdateAsync(EventHistory invoice)
    {
        _context.EventHistories.Update(invoice);
        await _context.SaveChangesAsync();    }

    public async Task DeleteAsync(int id)
    {
        var invoice = await _context.EventHistories.FindAsync(id);
        if (invoice != null)
        {
            _context.EventHistories.Remove(invoice);
            await _context.SaveChangesAsync();
        }    
    }
}