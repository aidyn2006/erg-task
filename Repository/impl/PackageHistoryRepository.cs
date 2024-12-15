using ERG_Task.Data;
using ERG_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace ERG_Task.Repository.impl;

public class PackageHistoryRepository : IPackageHistoryRepository
{
    private readonly AppDbContext _context;

    public PackageHistoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PackageHistory>> GetAllAsync()
    {
        return await _context.PackageHistories
            .ToListAsync();
    }

    public async Task<PackageHistory> GetByIdAsync(int id)
    {
        return await _context.PackageHistories
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(PackageHistory packageHistory)
    {
        await _context.PackageHistories.AddAsync(packageHistory);
        await _context.SaveChangesAsync();    
    }

    public async Task UpdateAsync(PackageHistory packageHistory)
    {
        _context.PackageHistories.Update(packageHistory);
        await _context.SaveChangesAsync();    }

    public async Task DeleteAsync(int id)
    {
        var packageHistory = await _context.PackageHistories.FindAsync(id);
        if (packageHistory != null)
        {
            _context.PackageHistories.Remove(packageHistory);
            await _context.SaveChangesAsync();
        }    
    }
}
