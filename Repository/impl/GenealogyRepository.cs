using ERG_Task.Data;
using ERG_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace ERG_Task.Repository.impl;

public class GenealogyRepository : IGenealogyRepository
{
    private readonly AppDbContext _context;

    public GenealogyRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Genealogy>> GetAllAsync()
    {
        return await _context.Genealogy
            .Include(g=>g.EventChild)
            .Include(g=>g.EventParent)
            .ToListAsync();
    }

    public async Task<Genealogy?> GetByIdAsync(int id)
    {
        return await _context.Genealogy
            .Include(g=>g.EventChild)
            .Include(g=>g.EventParent)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Genealogy invoice)
    {
        await _context.Genealogy.AddAsync(invoice);
        await _context.SaveChangesAsync();    
    }

    public async Task UpdateAsync(Genealogy invoice)
    {
        _context.Genealogy.Update(invoice);
        await _context.SaveChangesAsync();    }

    public async Task DeleteAsync(int id)
    {
        var invoice = await _context.Genealogy.FindAsync(id);
        if (invoice != null)
        {
            _context.Genealogy.Remove(invoice);
            await _context.SaveChangesAsync();
        }    
    }
}