using ERG_Task.Data;
using ERG_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace ERG_Task.Repository.impl;

public class PackageRepository : IPackageRepository
{
    private readonly AppDbContext _context;

    public PackageRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Package>> GetAllAsync()
    {
        return await _context.Packages
            .Include(s => s.Events)
            .Include(s=>s.Packages)
            .ToListAsync();
    }

    public async Task<Package> GetByIdAsync(int id)
    {
        return await _context.Packages
            .Include(s => s.Events)
            .Include(p => p.Packages) 
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Package package)
    {
        await _context.Packages.AddAsync(package);
        await _context.SaveChangesAsync();    
    }

    public async Task UpdateAsync(Package package)
    {
        _context.Packages.Update(package);
        await _context.SaveChangesAsync();    }

    public async Task DeleteAsync(int id)
    {
        var package = await _context.Packages.FindAsync(id);
        if (package != null)
        {
            _context.Packages.Remove(package);
            await _context.SaveChangesAsync();
        }    
    }
}