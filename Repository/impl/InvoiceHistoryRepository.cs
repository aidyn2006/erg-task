using ERG_Task.Data;
using ERG_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace ERG_Task.Repository.impl;

public class InvoiceHistoryRepository : IInvoiceHistoryRepository
{
    private readonly AppDbContext _context;

    public InvoiceHistoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<InvoiceHistory>> GetAllAsync()
    {
        return await _context.InvoiceHistories
            .ToListAsync();
    }

    public async Task<InvoiceHistory?> GetByIdAsync(int id)
    {
        return await _context.InvoiceHistories
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(InvoiceHistory invoice)
    {
        await _context.InvoiceHistories.AddAsync(invoice);
        await _context.SaveChangesAsync();    
    }

    public async Task UpdateAsync(InvoiceHistory invoice)
    {
        _context.InvoiceHistories.Update(invoice);
        await _context.SaveChangesAsync();    }

    public async Task DeleteAsync(int id)
    {
        var invoice = await _context.InvoiceHistories.FindAsync(id);
        if (invoice != null)
        {
            _context.InvoiceHistories.Remove(invoice);
            await _context.SaveChangesAsync();
        }    
    }
}