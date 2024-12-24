using ERG_Task.Data;
using ERG_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace ERG_Task.Repository.impl;

public class SupplyRepository : ISupplyRepository
{
    private readonly AppDbContext _context;

    public SupplyRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Supply>> GetAllAsync()
    {
        return await _context.Supplies
            // .Include(s => s.Events) 
            .ToListAsync();
    }

    public async Task<Supply> GetByIdAsync(int id)
    {
        return await _context.Supplies
            // .Include(s => s.Events) 
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task AddAsync(Supply supply)
    {
        await _context.Supplies.AddAsync(supply);
        await _context.SaveChangesAsync();    
    }

    public async Task UpdateAsync(Supply supply)
    {
        _context.Supplies.Update(supply);
        await _context.SaveChangesAsync();    }

    public async Task DeleteAsync(int id)
    {
        var trainSupply = await _context.Supplies.FindAsync(id);
        if (trainSupply != null)
        {
            _context.Supplies.Remove(trainSupply);
            await _context.SaveChangesAsync();
        }    
    }
}



